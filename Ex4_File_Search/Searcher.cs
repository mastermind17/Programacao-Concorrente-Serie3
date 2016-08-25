using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex4_File_Search
{
	public class Searcher
	{
		public Searcher()
		{
			Results = new SearchResults();
		}

		public SearchResults Results { get; }

		public Task<LinkedList<FileInfo>> GetFilesWithCorrectExtensionsAsync(string path, string[] extensions, CancellationToken token, SynchronizationContext context)
		{
			return Task.Factory.StartNew(() =>
			{
				var obj = new object();
				var filesWithCorrectExtension = new LinkedList<FileInfo>();
				var temp = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
				Parallel.For(
					(long)0, temp.Length,
					(i, state) =>
					{
						Interlocked.Increment(ref Results.TotalFilesFound);
						try
						{
							token.ThrowIfCancellationRequested();
						}
						catch (OperationCanceledException)
						{
							state.Break();
							return;
						}
						var f = new FileInfo(temp[i]);
						if (extensions.Contains(f.Extension))
						{
							lock (obj)
							{
								Interlocked.Increment(ref Results.FilesWithExtension);
								filesWithCorrectExtension.AddLast(f);
							}
						}
					});
				return filesWithCorrectExtension;
			}, token);
		}

		public Task<List<FileInfo>> ProcessContentForEachFileAsync(IEnumerable<FileInfo> listOfAllGoodFiles, string whatImLookingFor, CancellationToken cancellationToken, SynchronizationContext contextUi, IProgress<FileInfo> progressObserver)
		{
			return Task.Factory.StartNew(() =>
			{
				cancellationToken.ThrowIfCancellationRequested();
				var obj = new object();
				var list = new List<FileInfo>();
				Parallel.ForEach(listOfAllGoodFiles, async file =>
				{
					var lines = File.ReadAllLines(file.FullName);
					bool hasContent;
					try
					{
						hasContent = await SearchInternalTextAsync(lines, whatImLookingFor, cancellationToken);
					}
					catch (OperationCanceledException)
					{
						return;
					}
					if (hasContent)
					{
						lock (obj)
						{
							Interlocked.Increment(ref Results.FilesWithExtensionAndSequence);
							progressObserver.Report(file);
							list.Add(file);
						}
					}

				});
				return list;
			}, cancellationToken);
		}

		/// <summary>
		/// Checks if a certain file contains some given content.
		/// </summary>
		/// <param name="lines"></param>
		/// <param name="content"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		private static Task<bool> SearchInternalTextAsync(IReadOnlyList<string> lines, string content, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew(() =>
			{
				var loop = Parallel.For(0, lines.Count,
					(idx, state) =>
					{
						if (lines[idx].Contains(content))
						{
							state.Break();
						}
					});
				return !loop.IsCompleted;
			}, cancellationToken);
		}
	}
}
