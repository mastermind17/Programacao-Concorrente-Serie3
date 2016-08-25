using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex4_File_Search
{
	public class Program
	{
		// Used by the party wishing to request the cancellation
		private static CancellationTokenSource _tokenSource;
		private static readonly Searcher Searcher = new Searcher();
		private static readonly Stopwatch Stopwatch = new Stopwatch();
		private static string _path = @"C:\Users\mastermind\stuff\isel\pc\ses";
		private static string _sequence;
		private static string _extension;

		public static void Main(string[] args)
		{
			ParseArgs();
			Stopwatch.Start();
			DoSearchAsync();
			Stopwatch.Stop();
			PrintResults();
		}

		private static void ParseArgs()
		{
			// Ask for the arguments
			Console.WriteLine("In which url do you wanna search?\n(an empty line will use the solution directory)");
			var aux = Console.ReadLine();
			_path = !string.IsNullOrEmpty(aux) ? aux : _path;
			Console.WriteLine("Which sequence?");
			_sequence = Console.ReadLine();
			Console.WriteLine("And extension? (.cs, .txt, etc)");
			_extension = Console.ReadLine();
		}

		private static async void DoSearchAsync()
		{
			// Capture synchronization context while on the UI thread
			var contextUi = SynchronizationContext.Current;
			// Cancellation token
			_tokenSource = new CancellationTokenSource();
			// Token given to each asynchronous operation you wish to be able to cancel
			var cancellationToken = _tokenSource.Token;
			cancellationToken.Register(delegate { CheckCancellation(); });
			try
			{
				// Files with correct extension
				var listOfAllGoodFiles = await Searcher.GetFilesWithCorrectExtensionsAsync(_path, new[] { _extension }, cancellationToken, contextUi);
				cancellationToken.ThrowIfCancellationRequested();
				await Searcher.ProcessContentForEachFileAsync(listOfAllGoodFiles, _sequence, cancellationToken, contextUi, new Progress<FileInfo>(UpdateProgress));
				cancellationToken.ThrowIfCancellationRequested();
			}
			catch (OperationCanceledException)
			{
				Console.WriteLine(@"Search Cancelled!");
			}
		}

		private static void UpdateProgress(FileInfo file)
		{
			Console.WriteLine(file.DirectoryName + file.Name);
		}

		private static void PrintResults()
		{
			var elapsedSeconds = (double)Stopwatch.ElapsedMilliseconds / 1000;
			Console.ReadLine();
			Console.WriteLine($"Sequence: {_sequence}\nExtension: {_extension}\n");
			Console.WriteLine($"Search has Concluded in {elapsedSeconds} seconds!");
			Console.WriteLine("Total number of Files: " + Searcher.Results.TotalFilesFound);
			Console.WriteLine("Number of Files with the given extension: " + Searcher.Results.FilesWithExtension);
			Console.WriteLine("Number of Files with extension and sequence: " + Searcher.Results.FilesWithExtensionAndSequence);
			Console.WriteLine("\nHit <ENTER> to termiante the program!");
			Console.ReadLine();
		}

		private static bool CheckCancellation()
		{
			if (!_tokenSource.IsCancellationRequested)
				return false;
			Console.WriteLine(@"Search Cancelled!");
			return true;
		}
	}
}
