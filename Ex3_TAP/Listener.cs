using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex3_TAP
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

		TcpListener _srv;

		///  <summary>
		/// 	Server's main loop implementation.
		///  </summary>
		public void Run()
		{
			try
			{
				_srv = new TcpListener(IPAddress.Loopback, _portNumber);
				_srv.Start();

				AcceptClientAsync();

				Console.WriteLine("###################################\nType EXIT to terminate the server\n###################################");
				Console.ReadLine();
			}
			finally
			{
				Logger.Instance.LogMessage("Listener - Ending.");
				_srv.Stop();
			}
		}

		public void AcceptClientAsync()
		{
			if (Interlocked.CompareExchange(ref _waitingConnection, 1, 0) == 0)
			{
				Logger.Instance.LogMessage("Listener - Waiting for connection requests.");

				if (_isServerStopped)
				{
					_srv.Start();
					_isServerStopped = false;
				}
				_srv.AcceptTcpClientAsync().ContinueWith(HandleClientRequest);
			}
		}

		private int _connectionCount = 0;
		private const int MaxConnections = 1;
		private int _waitingConnection = 0;
		private bool _isServerStopped = false;

		private void HandleClientRequest(Task<TcpClient> task)
		{
			Interlocked.Decrement(ref _waitingConnection);

			TcpClient socket = task.Result;

			if (_connectionCount != MaxConnections)
				AcceptClientAsync();

			Interlocked.Increment(ref _connectionCount);
			if (_connectionCount == MaxConnections)
			{
				_srv.Stop();
				_isServerStopped = true;
			}

			string endPoint = socket.Client.RemoteEndPoint.ToString();

			socket.LingerState = new LingerOption(true, 10);

			Logger.Instance.LogMessage($"Listener - Connection established with {endPoint}.");

			// Instantiating protocol handler and associate it to the current TCP connection
			Handler protocolHandler = new Handler(socket.GetStream());

			// Synchronously process requests made through de current TCP connection
			protocolHandler.Run();

			// Indicate that the client has disconnected.
			Logger.Instance.LogMessage("Listener - Connection terminated with "
				+ endPoint);
			Program.ShowInfo(Store.Instance);

			// When we are done, decrement the counter and Accept a new client.
			Interlocked.Decrement(ref _connectionCount);

			if (_waitingConnection != 1)
			{
				AcceptClientAsync();
			}
		}
	}

}
