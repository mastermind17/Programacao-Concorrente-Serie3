using System.Windows.Forms;

namespace Ex5_Client
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.search_cancel_button = new System.Windows.Forms.Button();
			this.choose_dir_textbox = new System.Windows.Forms.TextBox();
			this.choose_dir_err_label = new System.Windows.Forms.Label();
			this.file_seq_err_label = new System.Windows.Forms.Label();
			this.file_seq_label = new System.Windows.Forms.Label();
			this.file_ext_err_label = new System.Windows.Forms.Label();
			this.file_ext_label = new System.Windows.Forms.Label();
			this.file_seq_textbox = new System.Windows.Forms.TextBox();
			this.file_ext_textbox = new System.Windows.Forms.TextBox();
			this.choose_dir_button = new System.Windows.Forms.Button();
			this.search_button = new System.Windows.Forms.Button();
			this.results_files_with_seq_label = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.results_files_with_seq_listView = new System.Windows.Forms.ListView();
			this.label2 = new System.Windows.Forms.Label();
			this.results_files_with_extension_label = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.result_total_files_label = new System.Windows.Forms.Label();
			this.result_label = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.search_cancel_button);
			this.splitContainer1.Panel1.Controls.Add(this.choose_dir_textbox);
			this.splitContainer1.Panel1.Controls.Add(this.choose_dir_err_label);
			this.splitContainer1.Panel1.Controls.Add(this.file_seq_err_label);
			this.splitContainer1.Panel1.Controls.Add(this.file_seq_label);
			this.splitContainer1.Panel1.Controls.Add(this.file_ext_err_label);
			this.splitContainer1.Panel1.Controls.Add(this.file_ext_label);
			this.splitContainer1.Panel1.Controls.Add(this.file_seq_textbox);
			this.splitContainer1.Panel1.Controls.Add(this.file_ext_textbox);
			this.splitContainer1.Panel1.Controls.Add(this.choose_dir_button);
			this.splitContainer1.Panel1.Controls.Add(this.search_button);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.results_files_with_seq_label);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.results_files_with_seq_listView);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.results_files_with_extension_label);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.result_total_files_label);
			this.splitContainer1.Panel2.Controls.Add(this.result_label);
			this.splitContainer1.Size = new System.Drawing.Size(1059, 407);
			this.splitContainer1.SplitterDistance = 349;
			this.splitContainer1.TabIndex = 0;
			// 
			// search_cancel_button
			// 
			this.search_cancel_button.Enabled = false;
			this.search_cancel_button.Location = new System.Drawing.Point(121, 342);
			this.search_cancel_button.Name = "search_cancel_button";
			this.search_cancel_button.Size = new System.Drawing.Size(111, 23);
			this.search_cancel_button.TabIndex = 11;
			this.search_cancel_button.Text = "Cancel Search";
			this.search_cancel_button.UseVisualStyleBackColor = true;
			this.search_cancel_button.Click += new System.EventHandler(this.search_cancel_button_Click);
			// 
			// choose_dir_textbox
			// 
			this.choose_dir_textbox.Location = new System.Drawing.Point(12, 18);
			this.choose_dir_textbox.Name = "choose_dir_textbox";
			this.choose_dir_textbox.ReadOnly = true;
			this.choose_dir_textbox.Size = new System.Drawing.Size(325, 20);
			this.choose_dir_textbox.TabIndex = 10;
			this.choose_dir_textbox.Text = "C:\\Users\\mastermind\\stuff\\isel\\pc\\ses";
			this.choose_dir_textbox.TextChanged += new System.EventHandler(this.choose_dir_textbox_TextChanged);
			// 
			// choose_dir_err_label
			// 
			this.choose_dir_err_label.AutoSize = true;
			this.choose_dir_err_label.ForeColor = System.Drawing.Color.Red;
			this.choose_dir_err_label.Location = new System.Drawing.Point(194, 74);
			this.choose_dir_err_label.Name = "choose_dir_err_label";
			this.choose_dir_err_label.Size = new System.Drawing.Size(35, 13);
			this.choose_dir_err_label.TabIndex = 9;
			this.choose_dir_err_label.Text = "label1";
			this.choose_dir_err_label.Visible = false;
			// 
			// file_seq_err_label
			// 
			this.file_seq_err_label.AutoSize = true;
			this.file_seq_err_label.ForeColor = System.Drawing.Color.Red;
			this.file_seq_err_label.Location = new System.Drawing.Point(195, 212);
			this.file_seq_err_label.Name = "file_seq_err_label";
			this.file_seq_err_label.Size = new System.Drawing.Size(35, 13);
			this.file_seq_err_label.TabIndex = 8;
			this.file_seq_err_label.Text = "label3";
			this.file_seq_err_label.Visible = false;
			// 
			// file_seq_label
			// 
			this.file_seq_label.AutoSize = true;
			this.file_seq_label.Location = new System.Drawing.Point(118, 169);
			this.file_seq_label.Name = "file_seq_label";
			this.file_seq_label.Size = new System.Drawing.Size(56, 13);
			this.file_seq_label.TabIndex = 7;
			this.file_seq_label.Text = "Sequence";
			// 
			// file_ext_err_label
			// 
			this.file_ext_err_label.AutoSize = true;
			this.file_ext_err_label.ForeColor = System.Drawing.Color.Red;
			this.file_ext_err_label.Location = new System.Drawing.Point(196, 139);
			this.file_ext_err_label.Name = "file_ext_err_label";
			this.file_ext_err_label.Size = new System.Drawing.Size(35, 13);
			this.file_ext_err_label.TabIndex = 6;
			this.file_ext_err_label.Text = "label1";
			this.file_ext_err_label.Visible = false;
			// 
			// file_ext_label
			// 
			this.file_ext_label.AutoSize = true;
			this.file_ext_label.Location = new System.Drawing.Point(118, 96);
			this.file_ext_label.Name = "file_ext_label";
			this.file_ext_label.Size = new System.Drawing.Size(53, 13);
			this.file_ext_label.TabIndex = 5;
			this.file_ext_label.Text = "Extension";
			// 
			// file_seq_textbox
			// 
			this.file_seq_textbox.Location = new System.Drawing.Point(121, 185);
			this.file_seq_textbox.Name = "file_seq_textbox";
			this.file_seq_textbox.Size = new System.Drawing.Size(111, 20);
			this.file_seq_textbox.TabIndex = 4;
			this.file_seq_textbox.Text = "for";
			// 
			// file_ext_textbox
			// 
			this.file_ext_textbox.Location = new System.Drawing.Point(121, 112);
			this.file_ext_textbox.Name = "file_ext_textbox";
			this.file_ext_textbox.Size = new System.Drawing.Size(111, 20);
			this.file_ext_textbox.TabIndex = 3;
			this.file_ext_textbox.Text = ".cs";
			this.file_ext_textbox.TextChanged += new System.EventHandler(this.file_ext_textbox_TextChanged);
			// 
			// choose_dir_button
			// 
			this.choose_dir_button.Location = new System.Drawing.Point(121, 44);
			this.choose_dir_button.Name = "choose_dir_button";
			this.choose_dir_button.Size = new System.Drawing.Size(111, 23);
			this.choose_dir_button.TabIndex = 1;
			this.choose_dir_button.Text = "Choose Directory";
			this.choose_dir_button.UseVisualStyleBackColor = true;
			this.choose_dir_button.Click += new System.EventHandler(this.choose_dir_button_Click);
			// 
			// search_button
			// 
			this.search_button.Location = new System.Drawing.Point(121, 301);
			this.search_button.Name = "search_button";
			this.search_button.Size = new System.Drawing.Size(111, 23);
			this.search_button.TabIndex = 0;
			this.search_button.Text = "Search Directory";
			this.search_button.UseVisualStyleBackColor = true;
			this.search_button.Click += new System.EventHandler(this.search_button_Click);
			// 
			// results_files_with_seq_label
			// 
			this.results_files_with_seq_label.AutoSize = true;
			this.results_files_with_seq_label.Location = new System.Drawing.Point(186, 128);
			this.results_files_with_seq_label.Name = "results_files_with_seq_label";
			this.results_files_with_seq_label.Size = new System.Drawing.Size(13, 13);
			this.results_files_with_seq_label.TabIndex = 18;
			this.results_files_with_seq_label.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(175, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Files with Extension and Sequence:";
			// 
			// results_files_with_seq_listView
			// 
			this.results_files_with_seq_listView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
			this.results_files_with_seq_listView.AutoArrange = false;
			this.results_files_with_seq_listView.FullRowSelect = true;
			this.results_files_with_seq_listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.results_files_with_seq_listView.Location = new System.Drawing.Point(3, 157);
			this.results_files_with_seq_listView.Name = "results_files_with_seq_listView";
			this.results_files_with_seq_listView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.results_files_with_seq_listView.Size = new System.Drawing.Size(691, 242);
			this.results_files_with_seq_listView.TabIndex = 16;
			this.results_files_with_seq_listView.UseCompatibleStateImageBehavior = false;
			this.results_files_with_seq_listView.View = System.Windows.Forms.View.Details;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(78, 101);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Files with Extension:";
			// 
			// results_files_with_extension_label
			// 
			this.results_files_with_extension_label.AutoSize = true;
			this.results_files_with_extension_label.Location = new System.Drawing.Point(186, 101);
			this.results_files_with_extension_label.Name = "results_files_with_extension_label";
			this.results_files_with_extension_label.Size = new System.Drawing.Size(13, 13);
			this.results_files_with_extension_label.TabIndex = 14;
			this.results_files_with_extension_label.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(97, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Number of Files:";
			// 
			// result_total_files_label
			// 
			this.result_total_files_label.AutoSize = true;
			this.result_total_files_label.Location = new System.Drawing.Point(186, 74);
			this.result_total_files_label.Name = "result_total_files_label";
			this.result_total_files_label.Size = new System.Drawing.Size(13, 13);
			this.result_total_files_label.TabIndex = 12;
			this.result_total_files_label.Text = "0";
			// 
			// result_label
			// 
			this.result_label.AutoSize = true;
			this.result_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
			this.result_label.Location = new System.Drawing.Point(3, 9);
			this.result_label.Name = "result_label";
			this.result_label.Size = new System.Drawing.Size(120, 31);
			this.result_label.TabIndex = 11;
			this.result_label.Text = "<status>";
			this.result_label.Visible = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1059, 407);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button search_button;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button choose_dir_button;
		private System.Windows.Forms.Label file_seq_err_label;
		private System.Windows.Forms.Label file_seq_label;
		private System.Windows.Forms.Label file_ext_err_label;
		private System.Windows.Forms.Label file_ext_label;
		private System.Windows.Forms.TextBox file_seq_textbox;
		private System.Windows.Forms.TextBox file_ext_textbox;
		private System.Windows.Forms.TextBox choose_dir_textbox;
		private System.Windows.Forms.Label choose_dir_err_label;
		private System.Windows.Forms.Label result_label;
		private System.Windows.Forms.Label result_total_files_label;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label results_files_with_extension_label;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListView results_files_with_seq_listView;
		private System.Windows.Forms.Label results_files_with_seq_label;
		private Button search_cancel_button;
	}
}

