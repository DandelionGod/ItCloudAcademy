using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Lesson_26_tcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
			int port = 80;
			Console.WriteLine("Start server on port " + port);
			TcpListener server = new TcpListener(IPAddress.Any, port);
			try
			{
				server.Start();
				while (true)
				{
					using (var client = server.AcceptTcpClient())  // stop and wait new client
					{
						var reader = new StreamReader(stream);
						Console.WriteLine("Client is connected: ", client.Client.RemoteEndPoint);

						var stream = client.GetStream();
						var reader = new StreamReader(stream);
						string message = null;
						do
						{
							message = reader.ReadLine();
							Console.WriteLine(message);
						}
						while (!string.IsNullOrEmpty(message));
					}
				}
			}
			finally
			{
				server.Stop();
			}


			Console.ReadKey();
        }
    }
}
