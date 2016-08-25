namespace Ex2_Client
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
            this.register_button = new System.Windows.Forms.Button();
            this.unregister_button = new System.Windows.Forms.Button();
            this.list_files_button = new System.Windows.Forms.Button();
            this.list_locations_button = new System.Windows.Forms.Button();
            this.list_files_listbox = new System.Windows.Forms.ListBox();
            this.list_locations_listbox = new System.Windows.Forms.ListBox();
            this.register_filename_textbox = new System.Windows.Forms.TextBox();
            this.register_addr_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.register_port_label = new System.Windows.Forms.Label();
            this.register_port_textbox = new System.Windows.Forms.TextBox();
            this.register_err_label = new System.Windows.Forms.Label();
            this.list_locations_textbox = new System.Windows.Forms.TextBox();
            this.list_locations_label = new System.Windows.Forms.Label();
            this.unregister_err_label = new System.Windows.Forms.Label();
            this.unregister_port_textbox = new System.Windows.Forms.TextBox();
            this.unregister_port_label = new System.Windows.Forms.Label();
            this.unregister_addr_label = new System.Windows.Forms.Label();
            this.unregister_filename_label = new System.Windows.Forms.Label();
            this.unregister_addr_textbox = new System.Windows.Forms.TextBox();
            this.unregister_filename_textbox = new System.Windows.Forms.TextBox();
            this.list_locations_err_label = new System.Windows.Forms.Label();
            this.connect_button = new System.Windows.Forms.Button();
            this.connect_ip_textbox = new System.Windows.Forms.TextBox();
            this.connect_port_textbox = new System.Windows.Forms.TextBox();
            this.connect_err_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // register_button
            // 
            this.register_button.Location = new System.Drawing.Point(30, 39);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(112, 24);
            this.register_button.TabIndex = 0;
            this.register_button.Text = "Register";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.register_handler);
            // 
            // unregister_button
            // 
            this.unregister_button.Location = new System.Drawing.Point(30, 207);
            this.unregister_button.Name = "unregister_button";
            this.unregister_button.Size = new System.Drawing.Size(112, 24);
            this.unregister_button.TabIndex = 1;
            this.unregister_button.Text = "Unregister";
            this.unregister_button.UseVisualStyleBackColor = true;
            this.unregister_button.Click += new System.EventHandler(this.unregister_handler);
            // 
            // list_files_button
            // 
            this.list_files_button.Location = new System.Drawing.Point(406, 39);
            this.list_files_button.Name = "list_files_button";
            this.list_files_button.Size = new System.Drawing.Size(112, 24);
            this.list_files_button.TabIndex = 2;
            this.list_files_button.Text = "List Files";
            this.list_files_button.UseVisualStyleBackColor = true;
            this.list_files_button.Click += new System.EventHandler(this.list_files_handler);
            // 
            // list_locations_button
            // 
            this.list_locations_button.Location = new System.Drawing.Point(406, 207);
            this.list_locations_button.Name = "list_locations_button";
            this.list_locations_button.Size = new System.Drawing.Size(112, 24);
            this.list_locations_button.TabIndex = 3;
            this.list_locations_button.Text = "List Locations";
            this.list_locations_button.UseVisualStyleBackColor = true;
            this.list_locations_button.Click += new System.EventHandler(this.list_locations_handler);
            // 
            // list_files_listbox
            // 
            this.list_files_listbox.FormattingEnabled = true;
            this.list_files_listbox.Location = new System.Drawing.Point(547, 39);
            this.list_files_listbox.Name = "list_files_listbox";
            this.list_files_listbox.Size = new System.Drawing.Size(237, 147);
            this.list_files_listbox.TabIndex = 4;
            // 
            // list_locations_listbox
            // 
            this.list_locations_listbox.FormattingEnabled = true;
            this.list_locations_listbox.Location = new System.Drawing.Point(547, 241);
            this.list_locations_listbox.Name = "list_locations_listbox";
            this.list_locations_listbox.Size = new System.Drawing.Size(237, 147);
            this.list_locations_listbox.TabIndex = 5;
            // 
            // register_filename_textbox
            // 
            this.register_filename_textbox.Location = new System.Drawing.Point(148, 79);
            this.register_filename_textbox.Name = "register_filename_textbox";
            this.register_filename_textbox.Size = new System.Drawing.Size(176, 20);
            this.register_filename_textbox.TabIndex = 6;
            // 
            // register_addr_textbox
            // 
            this.register_addr_textbox.Location = new System.Drawing.Point(148, 105);
            this.register_addr_textbox.Name = "register_addr_textbox";
            this.register_addr_textbox.Size = new System.Drawing.Size(176, 20);
            this.register_addr_textbox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "File Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Address";
            // 
            // register_port_label
            // 
            this.register_port_label.AutoSize = true;
            this.register_port_label.Location = new System.Drawing.Point(116, 134);
            this.register_port_label.Name = "register_port_label";
            this.register_port_label.Size = new System.Drawing.Size(26, 13);
            this.register_port_label.TabIndex = 10;
            this.register_port_label.Text = "Port";
            // 
            // register_port_textbox
            // 
            this.register_port_textbox.Location = new System.Drawing.Point(148, 131);
            this.register_port_textbox.Name = "register_port_textbox";
            this.register_port_textbox.Size = new System.Drawing.Size(176, 20);
            this.register_port_textbox.TabIndex = 11;
            // 
            // register_err_label
            // 
            this.register_err_label.AutoSize = true;
            this.register_err_label.Location = new System.Drawing.Point(145, 173);
            this.register_err_label.Name = "register_err_label";
            this.register_err_label.Size = new System.Drawing.Size(0, 13);
            this.register_err_label.TabIndex = 12;
            this.register_err_label.Visible = false;
            // 
            // list_locations_textbox
            // 
            this.list_locations_textbox.Location = new System.Drawing.Point(591, 207);
            this.list_locations_textbox.Name = "list_locations_textbox";
            this.list_locations_textbox.Size = new System.Drawing.Size(193, 20);
            this.list_locations_textbox.TabIndex = 13;
            // 
            // list_locations_label
            // 
            this.list_locations_label.AutoSize = true;
            this.list_locations_label.Location = new System.Drawing.Point(544, 210);
            this.list_locations_label.Name = "list_locations_label";
            this.list_locations_label.Size = new System.Drawing.Size(41, 13);
            this.list_locations_label.TabIndex = 14;
            this.list_locations_label.Text = "For File";
            // 
            // unregister_err_label
            // 
            this.unregister_err_label.AutoSize = true;
            this.unregister_err_label.Location = new System.Drawing.Point(145, 339);
            this.unregister_err_label.Name = "unregister_err_label";
            this.unregister_err_label.Size = new System.Drawing.Size(0, 13);
            this.unregister_err_label.TabIndex = 21;
            this.unregister_err_label.Visible = false;
            // 
            // unregister_port_textbox
            // 
            this.unregister_port_textbox.Location = new System.Drawing.Point(148, 297);
            this.unregister_port_textbox.Name = "unregister_port_textbox";
            this.unregister_port_textbox.Size = new System.Drawing.Size(176, 20);
            this.unregister_port_textbox.TabIndex = 20;
            // 
            // unregister_port_label
            // 
            this.unregister_port_label.AutoSize = true;
            this.unregister_port_label.Location = new System.Drawing.Point(116, 300);
            this.unregister_port_label.Name = "unregister_port_label";
            this.unregister_port_label.Size = new System.Drawing.Size(26, 13);
            this.unregister_port_label.TabIndex = 19;
            this.unregister_port_label.Text = "Port";
            // 
            // unregister_addr_label
            // 
            this.unregister_addr_label.AutoSize = true;
            this.unregister_addr_label.Location = new System.Drawing.Point(97, 275);
            this.unregister_addr_label.Name = "unregister_addr_label";
            this.unregister_addr_label.Size = new System.Drawing.Size(45, 13);
            this.unregister_addr_label.TabIndex = 18;
            this.unregister_addr_label.Text = "Address";
            // 
            // unregister_filename_label
            // 
            this.unregister_filename_label.AutoSize = true;
            this.unregister_filename_label.Location = new System.Drawing.Point(88, 249);
            this.unregister_filename_label.Name = "unregister_filename_label";
            this.unregister_filename_label.Size = new System.Drawing.Size(54, 13);
            this.unregister_filename_label.TabIndex = 17;
            this.unregister_filename_label.Text = "File Name";
            // 
            // unregister_addr_textbox
            // 
            this.unregister_addr_textbox.Location = new System.Drawing.Point(148, 271);
            this.unregister_addr_textbox.Name = "unregister_addr_textbox";
            this.unregister_addr_textbox.Size = new System.Drawing.Size(176, 20);
            this.unregister_addr_textbox.TabIndex = 16;
            // 
            // unregister_filename_textbox
            // 
            this.unregister_filename_textbox.Location = new System.Drawing.Point(148, 245);
            this.unregister_filename_textbox.Name = "unregister_filename_textbox";
            this.unregister_filename_textbox.Size = new System.Drawing.Size(176, 20);
            this.unregister_filename_textbox.TabIndex = 15;
            // 
            // list_locations_err_label
            // 
            this.list_locations_err_label.AutoSize = true;
            this.list_locations_err_label.Location = new System.Drawing.Point(550, 409);
            this.list_locations_err_label.Name = "list_locations_err_label";
            this.list_locations_err_label.Size = new System.Drawing.Size(35, 13);
            this.list_locations_err_label.TabIndex = 22;
            this.list_locations_err_label.Text = "label3";
            this.list_locations_err_label.Visible = false;
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(30, 13);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(112, 23);
            this.connect_button.TabIndex = 23;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_handler);
            // 
            // connect_ip_textbox
            // 
            this.connect_ip_textbox.Location = new System.Drawing.Point(148, 15);
            this.connect_ip_textbox.Name = "connect_ip_textbox";
            this.connect_ip_textbox.Size = new System.Drawing.Size(100, 20);
            this.connect_ip_textbox.TabIndex = 24;
            this.connect_ip_textbox.Text = "127.0.0.1";
            // 
            // connect_port_textbox
            // 
            this.connect_port_textbox.Location = new System.Drawing.Point(254, 15);
            this.connect_port_textbox.Name = "connect_port_textbox";
            this.connect_port_textbox.Size = new System.Drawing.Size(70, 20);
            this.connect_port_textbox.TabIndex = 25;
            this.connect_port_textbox.Text = "8888";
            // 
            // connect_err_label
            // 
            this.connect_err_label.AutoSize = true;
            this.connect_err_label.Location = new System.Drawing.Point(330, 18);
            this.connect_err_label.Name = "connect_err_label";
            this.connect_err_label.Size = new System.Drawing.Size(35, 13);
            this.connect_err_label.TabIndex = 26;
            this.connect_err_label.Text = "label3";
            this.connect_err_label.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 464);
            this.Controls.Add(this.connect_err_label);
            this.Controls.Add(this.connect_port_textbox);
            this.Controls.Add(this.connect_ip_textbox);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.list_locations_err_label);
            this.Controls.Add(this.unregister_err_label);
            this.Controls.Add(this.unregister_port_textbox);
            this.Controls.Add(this.unregister_port_label);
            this.Controls.Add(this.unregister_addr_label);
            this.Controls.Add(this.unregister_filename_label);
            this.Controls.Add(this.unregister_addr_textbox);
            this.Controls.Add(this.unregister_filename_textbox);
            this.Controls.Add(this.list_locations_label);
            this.Controls.Add(this.list_locations_textbox);
            this.Controls.Add(this.register_err_label);
            this.Controls.Add(this.register_port_textbox);
            this.Controls.Add(this.register_port_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.register_addr_textbox);
            this.Controls.Add(this.register_filename_textbox);
            this.Controls.Add(this.list_locations_listbox);
            this.Controls.Add(this.list_files_listbox);
            this.Controls.Add(this.list_locations_button);
            this.Controls.Add(this.list_files_button);
            this.Controls.Add(this.unregister_button);
            this.Controls.Add(this.register_button);
            this.Name = "Form1";
            this.Text = "PC_SE3-Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.Button unregister_button;
        private System.Windows.Forms.Button list_files_button;
        private System.Windows.Forms.Button list_locations_button;
        private System.Windows.Forms.ListBox list_files_listbox;
        private System.Windows.Forms.ListBox list_locations_listbox;
        private System.Windows.Forms.TextBox register_filename_textbox;
        private System.Windows.Forms.TextBox register_addr_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label register_port_label;
        private System.Windows.Forms.TextBox register_port_textbox;
        private System.Windows.Forms.Label register_err_label;
        private System.Windows.Forms.TextBox list_locations_textbox;
        private System.Windows.Forms.Label list_locations_label;
        private System.Windows.Forms.Label unregister_err_label;
        private System.Windows.Forms.TextBox unregister_port_textbox;
        private System.Windows.Forms.Label unregister_port_label;
        private System.Windows.Forms.Label unregister_addr_label;
        private System.Windows.Forms.Label unregister_filename_label;
        private System.Windows.Forms.TextBox unregister_addr_textbox;
        private System.Windows.Forms.TextBox unregister_filename_textbox;
        private System.Windows.Forms.Label list_locations_err_label;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.TextBox connect_ip_textbox;
        private System.Windows.Forms.TextBox connect_port_textbox;
        private System.Windows.Forms.Label connect_err_label;

    }
}

