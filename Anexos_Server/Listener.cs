using System.Net;
using System.Net.Sockets;

namespace Anexos_Server
{
	/// <summary>
	/// This class instances are file tracking servers. They are responsible for accepting 
	/// and managing established TCP connections.
	/// </summary>
	public sealed class Listener
	{
		/// <summary>
		/// TCP port number in use.
		/// </summary>
		private readonly int _portNumber;

		/// <summary> Initiates a tracking server instance.</summary>
		/// <param name="portNumber"> The TCP port number to be used.</param>
		public Listener(int portNumber) { this._portNumber = portNumber; }

		/// <summary>
		///	Server's main loop implementation.
		/// </summary>
		/// <param name="log"> The Logger instance to be used.</param>
		public void Run(Logger log)
		{
			TcpListener srv = null;
			try
			{
				srv = new TcpListener(IPAddress.Loopback, _portNumber);
				srv.Start();
				while (true)
				{
					log.LogMessage("Listener - Waiting for connection requests.");
					using (var socket = srv.AcceptTcpClient())
					{
						socket.LingerState = new LingerOption(true, 10);
						log.LogMessage($"Listener - Connection established with {socket.Client.RemoteEndPoint}.");
						// Instantiating protocol handler and associate it to the current TCP connection
						var protocolHandler = new Handler(socket.GetStream(), log);
						// Synchronously process requests made through de current TCP connection
						protocolHandler.Run();
					}

					Program.ShowInfo(Store.Instance);
				}
			}
			finally
			{
				log.LogMessage("Listener - Ending.");
				srv?.Stop();
			}
		}

	}
}
