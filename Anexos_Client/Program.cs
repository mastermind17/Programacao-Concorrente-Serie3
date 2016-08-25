using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Anexos_Client
{
    public class Program
    {
        private const int Port = 8888;

        private static void Register(IEnumerable<string> files, string adress, ushort port)
        {
            using (var client = new TcpClient())
            {
                client.Connect(IPAddress.Loopback, Port);

                var output = new StreamWriter(client.GetStream());

                // Send request type line
                output.WriteLine("REGISTER");

                // Send message payload
                foreach (var file in files)
                    output.WriteLine($"{file}:{adress}:{port}");

                // Send message end mark
                output.WriteLine();

                output.Close();
                client.Close();
            }
        }

        private static void Unregister(string file, string adress, ushort port)
        {
            using (var client = new TcpClient())
            {
                client.Connect(IPAddress.Loopback, Port);

                var output = new StreamWriter(client.GetStream());

                // Send request type line
                output.WriteLine("UNREGISTER");
                // Send message payload
                output.WriteLine($"{file}:{adress}:{port}");
                // Send message end mark
                output.WriteLine();

                output.Close();
                client.Close();
            }
        }

        private static void ListFiles()
        {
            using (var socket = new TcpClient())
            {
                socket.Connect(IPAddress.Loopback, Port);

                var output = new StreamWriter(socket.GetStream());

                // Send request type line
                output.WriteLine("LIST_FILES");
                // Send message end mark and flush it
                output.WriteLine();
                output.Flush();

                // Read response
                string line;
                var input = new StreamReader(socket.GetStream());
                while ((line = input.ReadLine()) != null && line != string.Empty)
                    Console.WriteLine(line);

                output.Close();
                socket.Close();
            }
        }

        private static void ListLocations(string fileName)
        {
            using (var socket = new TcpClient())
            {
                socket.Connect(IPAddress.Loopback, Port);

                var output = new StreamWriter(socket.GetStream());

                // Send request type line
                output.WriteLine("LIST_LOCATIONS");
                // Send message payload
                output.WriteLine(fileName);
                // Send message end mark and flush it
                output.WriteLine();
                output.Flush();

                // Read response
                string line;
                var input = new StreamReader(socket.GetStream());
                while ((line = input.ReadLine()) != null && line != string.Empty)
                    Console.WriteLine(line);

                output.Close();
                socket.Close();
            }
        }

        public static void Main()
        {
            Register(new[] { "xpto", "ypto", "zpto" }, "192.1.1.1", 5555);
            Register(new[] { "xpto", "ypto" }, "192.1.1.2", 5555);
            Register(new[] { "xpto" }, "192.1.1.3", 5555);

            Console.WriteLine("List files:");
            ListFiles();
            Console.WriteLine("List locations xpto");
            ListLocations("xpto");
            Console.WriteLine("List locations ypto");
            ListLocations("ypto");
            Console.WriteLine("List locations zpto");
            ListLocations("zpto");
            Console.ReadLine();

            Unregister("zpto", "192.1.1.1", 5555);

            Console.WriteLine("List files:");
            ListFiles();
            Console.WriteLine("List locations xpto");
            ListLocations("xpto");
            Console.WriteLine("List locations ypto");
            ListLocations("ypto");
            Console.WriteLine("List locations zpto");
            ListLocations("zpto");
            Console.ReadLine();

            Unregister("xpto", "192.1.1.1", 5555);
            Unregister("ypto", "192.1.1.1", 5555);

            Console.WriteLine("List files:");
            ListFiles();
            Console.WriteLine("List locations xpto");
            ListLocations("xpto");
            Console.WriteLine("List locations ypto");
            ListLocations("ypto");
            Console.WriteLine("List locations zpto");
            ListLocations("zpto");
            Console.ReadLine();
        }
    }
}
