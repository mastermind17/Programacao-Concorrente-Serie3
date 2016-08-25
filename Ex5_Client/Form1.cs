using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex4_File_Search;

namespace Ex5_Client
{
	public partial class Form1 : Form
	{
		private Searcher _searcher;
		// Used by the party wishing to request the cancellation
		private CancellationTokenSource _tokenSource;

		public Form1()
		{
			InitializeComponent();
		}

		private void choose_dir_button_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.SelectedPath = choose_dir_textbox.Text;
			var res = folderBrowserDialog1.ShowDialog();
			if (res == DialogResult.OK)
			{
				choose_dir_textbox.Text = folderBrowserDialog1.SelectedPath;
				choose_dir_textbox.ReadOnly = true;
			}
		}

		private async void search_button_Click(object sender, EventArgs e)
		{
			ResetFormErrLabels();
			ResetResults();
			// Path
			var path = choose_dir_textbox.Text;
			if (path == string.Empty)
			{
				choose_dir_err_label.Text = @"Select a Directory!";
				choose_dir_err_label.Visible = true;
			}
			// Extension
			var extension = file_ext_textbox.Text;
			if (extension == string.Empty)
			{
				file_ext_err_label.Text = @"Select an extension!";
				file_ext_err_label.Visible = true;
			}
			// Sequence
			var sequence = file_seq_textbox.Text;
			if (sequence == string.Empty)
			{
				file_seq_err_label.Text = @"Select a sequence!";
				file_seq_err_label.Visible = true;
			}
			// Capture synchronization context while on the UI thread
			var contextUi = SynchronizationContext.Current;
			// Cancellation token
			_tokenSource = new CancellationTokenSource();
			// Token given to each asynchronous operation you wish to be able to cancel
			var cancellationToken = _tokenSource.Token;
			cancellationToken.Register(delegate { CheckCancellation(); });
			// Start search
			_searcher = new Searcher();
			search_button.Enabled = false;
			search_cancel_button.Enabled = true;
			result_label.Text = @"Started Search!";
			result_label.Visible = true;
			try
			{
				// Files with correct extension
				var listOfAllGoodFiles = await _searcher.GetFilesWithCorrectExtensionsAsync(path, new[] { extension }, cancellationToken, contextUi);
				cancellationToken.ThrowIfCancellationRequested();
				await _searcher.ProcessContentForEachFileAsync(listOfAllGoodFiles, sequence, cancellationToken, contextUi, new Progress<FileInfo>(UpdateProgress));
				cancellationToken.ThrowIfCancellationRequested();
				AfterSearchEnded();
			}
			catch (OperationCanceledException)
			{
				result_label.Text = @"Search Cancelled!";
				//ResetConfig();
			}
			//reposição de configuracoes
			_tokenSource.Dispose();
			search_button.Enabled = true;
			search_cancel_button.Enabled = false;

		}

		private void AfterSearchEnded()
		{
			// Resize window
			results_files_with_seq_listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			// Reset buttons
			result_label.Text = @"Finished Searching!";
			search_button.Enabled = true;
			search_cancel_button.Enabled = false;
		}

		private void ResetFormErrLabels()
		{
			file_seq_err_label.Visible = false;
			file_ext_err_label.Visible = false;
			choose_dir_err_label.Visible = false;
		}

		private void ResetResults()
		{
			results_files_with_seq_listView.Clear();
			results_files_with_seq_listView.Columns.Add("File Path");
			results_files_with_seq_label.Text = @"0";
			results_files_with_extension_label.Text = @"0";
			result_total_files_label.Text = @"0";
		}

		private void search_cancel_button_Click(object sender, EventArgs e)
		{
			_tokenSource.Cancel();
		}

		private bool CheckCancellation()
		{
			if (!_tokenSource.IsCancellationRequested)
				return false;
			result_label.Text = @"Search Cancelled!";
			search_button.Enabled = true;
			search_cancel_button.Enabled = false;
			return true;
		}

		private void UpdateProgress(FileInfo file)
		{
			// Update counters labels
			result_total_files_label.Text = _searcher.Results.TotalFilesFound.ToString();
			results_files_with_extension_label.Text = _searcher.Results.FilesWithExtension.ToString();
			results_files_with_seq_label.Text = _searcher.Results.FilesWithExtensionAndSequence.ToString();
			results_files_with_seq_listView.Items.Add(file.DirectoryName + file.Name);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void choose_dir_textbox_TextChanged(object sender, EventArgs e)
		{

		}

		private void file_ext_textbox_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
