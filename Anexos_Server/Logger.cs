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

namespace Anexos_Server
{
	// Logger single-threaded.
	public class Logger
	{
		private readonly TextWriter _writer;
		private DateTime _startTime;
		private int _numRequests;

		public Logger() : this(Console.Out) { }
		public Logger(string logfile) : this(new StreamWriter(new FileStream(logfile, FileMode.Append, FileAccess.Write))) { }
		public Logger(TextWriter awriter)
		{
			_numRequests = 0;
			_writer = awriter;
		}

		public void Start()
		{
			_startTime = DateTime.Now;
			_writer.WriteLine();
			_writer.WriteLine($"::- LOG STARTED @ {DateTime.Now} -::");
			_writer.WriteLine();
		}

		public void LogMessage(string msg)
		{
			_writer.WriteLine($"{DateTime.Now}: {msg}");
		}

		public void IncrementRequests()
		{
			++_numRequests;
		}

		public void Stop()
		{
			var elapsed = DateTime.Now.Ticks - _startTime.Ticks;
			_writer.WriteLine();
			LogMessage($"Running for {elapsed / 10000000L} second(s)");
			LogMessage($"Number of request(s): {_numRequests}");
			_writer.WriteLine();
			_writer.WriteLine($"::- LOG STOPPED @ {DateTime.Now} -::");
			_writer.Close();
		}
	}
}
