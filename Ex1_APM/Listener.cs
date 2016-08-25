using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Ex1_APM
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
				Console.WriteLine("\n###################################################\n     Hit <ENTER> to terminate the server\n###################################################\n");

				_srv = new TcpListener(IPAddress.Loopback, _portNumber);
				_srv.Start();

				// Begin Accepting requests from clients.
				AcceptClient();

				Console.ReadLine();
			}
			finally
			{
				Logger.Instance.LogMessage("Listener - Ending.");
				_srv.Stop();
				Console.ReadLine();
			}
		}
		/// <summary>
		/// Connection currently being used
		/// </summary>
		private int _connectionCount = 0;

		private const int MaxConnections = 1;

		/// <summary>
		/// WaitingConnection is a boolean represented by an int that represents if the socket is already awaiting a connection.
		/// We use this flag to make sure that we dont overload the socket with unnecessary connections.
		/// </summary>
		private int _waitingConnection = 0;
		private bool _isServerStopped = false;
		public void AcceptClient()
		{

			if (Interlocked.CompareExchange(ref _waitingConnection, 1, 0) == 0)
			{
				Logger.Instance.LogMessage(
					$"Listener - Waiting for connection requests on Thread: {Thread.CurrentThread.ManagedThreadId}");
				if (_isServerStopped)
				{
					_srv.Start();
					_isServerStopped = false;
				}
				_srv.BeginAcceptTcpClient(
				HandleClientRequest, _srv);
			}
		}

		private void HandleClientRequest(IAsyncResult asyncRes)
		{

			Interlocked.Decrement(ref _waitingConnection);

			try
			{
				using (TcpClient socket = ((TcpListener)asyncRes.AsyncState).EndAcceptTcpClient(asyncRes))
				{
					// Only set a parallel listener if we haven't exceeded the maximum number of Clients.
					if (_connectionCount < MaxConnections)
						AcceptClient();


					Interlocked.Increment(ref _connectionCount);
					if (_connectionCount == MaxConnections)
					{
						_srv.Stop();
						_isServerStopped = true;
					}
					socket.LingerState = new LingerOption(true, 10);

					string endPoint = socket.Client.RemoteEndPoint.ToString();

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
						AcceptClient();
					}
				}
			}
			catch (Exception)
			{
				// ignored
			}
		}
	}
}
