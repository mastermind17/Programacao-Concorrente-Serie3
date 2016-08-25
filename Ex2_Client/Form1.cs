using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;

using System.IO;

namespace Ex2_Client
{
	public partial class Form1 : Form
	{

		private TcpClient client;
		private StreamWriter output;
		private StreamReader input;

		public Form1()
		{
			InitializeComponent();
		}

		private void connect_handler(object sender, EventArgs e)
		{
			this.connect_err_label.Visible = false;

			// Check if there is currently a Connection Established, in which case we termiante it.
			if (client != null && client.Connected)
			{
				client.Close();

				this.connect_button.Text = "Connect";
				this.connect_ip_textbox.ReadOnly = false;
				this.connect_port_textbox.ReadOnly = false;
				return;
			}

			string ipAddr = this.connect_ip_textbox.Text;
			if (ipAddr == String.Empty)
			{
				this.connect_err_label.Text = "No Address specified!";
				this.connect_err_label.Visible = true;
				return;
			}

			string port = this.connect_port_textbox.Text;
			if (port == String.Empty)
			{
				this.connect_err_label.Text = "No Port specified!";
				this.connect_err_label.Visible = true;
				return;
			}

			// Connect to Server!
			client = new TcpClient();
			try
			{
				client.Connect(ipAddr, Int32.Parse(port));
			}
			catch (Exception connectExc)
			{
				this.connect_err_label.Text = "Unable to connect to the server!";
				this.connect_err_label.Visible = true;
				return;
			}

			// Create our Streams.
			output = new StreamWriter(client.GetStream());
			input = new StreamReader(client.GetStream());

			this.connect_button.Text = "Disconnect";
			this.connect_ip_textbox.ReadOnly = true;
			this.connect_port_textbox.ReadOnly = true;
		}

		private async void register_handler(object sender, EventArgs e)
		{
			if (client == null || !client.Connected) { this.connect_err_label.Text = "You Must connect to a server!"; this.connect_err_label.Visible = true; return; }

			string filename = this.register_filename_textbox.Text;
			if (filename == String.Empty)
			{
				this.register_err_label.Text = "No File specified!";
				this.register_err_label.Visible = true;
				return;
			}

			string addr = this.register_addr_textbox.Text;
			if (addr == String.Empty)
			{
				this.register_err_label.Text = "No Address specified!";
				this.register_err_label.Visible = true;
				return;
			}
			else
			{
				try
				{
					IPAddress.Parse(addr);
				}
				catch (FormatException formatException)
				{
					this.register_err_label.Text = "Incorrect IP address format!";
					this.register_err_label.Visible = true;
					return;
				}
			}

			string port = this.register_port_textbox.Text;
			if (port == String.Empty)
			{
				this.register_err_label.Text = "No Port specified!";
				this.register_err_label.Visible = true;
				return;
			}

			// Request Type
			await output.WriteLineAsync("REGISTER");
			// Request Payload
			await output.WriteLineAsync(string.Format("{0}:{1}:{2}", filename, addr, port));
			// Request End Mark
			await output.WriteLineAsync();
			await output.FlushAsync();

			ResestRegisterFields();
		}

		private void ResestRegisterFields()
		{
			this.register_addr_textbox.Clear();
			this.register_filename_textbox.Clear();
			this.register_port_textbox.Clear();
			this.register_err_label.Visible = false;
		}

		private async void unregister_handler(object sender, EventArgs e)
		{
			if (client == null || !client.Connected) { this.connect_err_label.Text = "You Must connect to a server!"; this.connect_err_label.Visible = true; return; }

			string filename = this.unregister_filename_textbox.Text;
			if (filename == String.Empty)
			{
				this.unregister_err_label.Text = "No File specified!";
				this.unregister_err_label.Visible = true;
				return;
			}

			string addr = this.unregister_addr_textbox.Text;
			if (addr == String.Empty)
			{
				this.unregister_err_label.Text = "No Address specified!";
				this.unregister_err_label.Visible = true;
				return;
			}
			else
			{
				try
				{
					IPAddress.Parse(addr);
				}
				catch (FormatException formatException)
				{
					unregister_err_label.Text = @"Incorrect IP address format!";
					unregister_err_label.Visible = true;
					return;
				}
			}

			var port = unregister_port_textbox.Text;
			if (port == string.Empty)
			{
				unregister_err_label.Text = @"No Port specified!";
				unregister_err_label.Visible = true;
				return;
			}

			// Request Type
			await output.WriteLineAsync("UNREGISTER");
			// Request Payload
			await output.WriteLineAsync($"{filename}:{addr}:{port}");
			// Request End Mark
			await output.WriteLineAsync();
			await output.FlushAsync();

			ResetUnregisterFields();
		}

		private void ResetUnregisterFields()
		{
			unregister_addr_textbox.Clear();
			unregister_filename_textbox.Clear();
			unregister_port_textbox.Clear();
			unregister_err_label.Visible = false;
		}

		private async void list_files_handler(object sender, EventArgs e)
		{
			if (client == null || !client.Connected)
			{
				connect_err_label.Text = @"You Must connect to a server!";
				connect_err_label.Visible = true;
				return;
			}

			list_files_listbox.Items.Clear();
			// Request Type
			await output.WriteLineAsync("LIST_FILES");

			// Request End Mark
			await output.WriteLineAsync();
			await output.FlushAsync();

			// Read response
			string line;

			// Asynchroous Read Form Stream.
			while ((line = await input.ReadLineAsync()) != null && line != string.Empty)
			{
				list_files_listbox.Items.Add(line);
			}
		}

		private async void list_locations_handler(object sender, EventArgs e)
		{
			if (client == null || !client.Connected) { return; }

			list_locations_err_label.Visible = false;
			list_locations_listbox.Items.Clear();

			var filename = list_locations_textbox.Text;
			if (filename == string.Empty)
			{
				list_locations_err_label.Text = @"No File specified!";
				list_locations_err_label.Visible = true;
				return;
			}

			// Request Type
			await output.WriteLineAsync("LIST_LOCATIONS");

			// Reuqest Payload
			await output.WriteLineAsync(filename);

			// Reuqest End Mark
			await output.WriteLineAsync();
			await output.FlushAsync();

			// Read response
			string line;
			var reader = new StreamReader(client.GetStream());
			while ((line = await reader.ReadLineAsync()) != null && line != string.Empty)
				list_locations_listbox.Items.Add(line);
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			// Close the StreamWriter.
			output?.Close();
			// cosing this Stream, will close Writer as well. ????
			input?.Close();

			// Terminate the connection with the server.
			client?.Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
