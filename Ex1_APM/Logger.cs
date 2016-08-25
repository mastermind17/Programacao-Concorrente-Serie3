/*
 * INSTITUTO SUPERIOR DE ENGENHARIA DE LISBOA
 * Licenciatura em Engenharia Informática e de Computadores
 *
 * Programação Concorrente - Inverno de 2009-2010
 * João Trindade
 *
 * Código base para a 3ª Série de Exercícios.
 *
 */

using System;
using System.IO;
using System.Threading;

namespace Ex1_APM
{
	/// Logger multi-threaded.
	public class Logger
	{
		private readonly TextWriter _writer;

		private DateTime _startTime;

		private int _numRequests;

		//non-blocking queue from serie 2
		private readonly ConcurrentQueue<Log> _queue;

		private volatile bool _loggerShutdown;

		public bool LoggerShutdown
		{
			get { return _loggerShutdown; }
			set { _loggerShutdown = value; }
		}

		public static Logger Instance { get; } = new Logger();

		private Logger() : this(Console.Out) { }
		/*
                private Logger(string logfile) : this(new StreamWriter(new FileStream(logfile, FileMode.Append, FileAccess.Write))) { }
        */
		private Logger(TextWriter awriter)
		{
			_loggerShutdown = false;
			_numRequests = 0;
			_writer = awriter;
			_queue = new ConcurrentQueue<Log>();
		}

		public void Start()
		{
			_startTime = DateTime.Now;
			_writer.WriteLine();
			_writer.WriteLine($"::- LOG STARTED @ {DateTime.Now} -::");
			_writer.WriteLine();

			while (!LoggerShutdown)
			{
				Log item;
				if ((item = _queue.TryDequeue()) != null)
					_writer.WriteLine("\n" + item);
			}
		}

		public void LogMessage(string msg)
		{
			//_writer.WriteLine(String.Format("{0}: {1}", DateTime.Now, msg));
			_queue.Enqueue(new Log(msg));
		}

		public void IncrementRequests()
		{
			Interlocked.Increment(ref _numRequests);
		}

		public void Stop()
		{
			var elapsed = DateTime.Now.Ticks - _startTime.Ticks;
			_writer.WriteLine();
			LogMessage($"Running for {elapsed/10000000L} second(s)");
			LogMessage($"Number of request(s): {_numRequests}");
			_writer.WriteLine();
			_writer.WriteLine($"::- LOG STOPPED @ {DateTime.Now} -::");
			_writer.Close();
			Console.WriteLine("Press any key to continue..");
			Console.ReadLine();
			_loggerShutdown = true;
		}


		/// <summary>
		/// Logger's encapsulation class to insert into the queue.
		/// </summary>
		private class Log
		{
			private string Message { get; set; }
			private string LogTime { get; set; }

			public Log(string message)
			{
				Message = message;
				LogTime = DateTime.Now.ToString("hh:mm:ss.fff tt");
			}

			public override string ToString()
			{
				return "" + LogTime + Message;
			}
		}
	}
}
