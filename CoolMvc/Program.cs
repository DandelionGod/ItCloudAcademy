using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CoolMvc
{
	public interface IHandler
	{
		bool Handle(WebContext context);
	}



	public class CoolWebRequest
	{
		public string RawRequest { get; internal set; }
	}

	public class CoolWebResponse
	{
		public string Content { get; set; }
	}

	public class WebContext
	{
		public CoolWebRequest Request { get; set; } = new CoolWebRequest();
		public CoolWebResponse Response { get; set; } = new CoolWebResponse();
	}

	public class CoolWebServer : IDisposable
	{
		private readonly TcpListener _tcpListener;
		private readonly List<IHandler> _handlers = new List<IHandler>();

		public CoolWebServer()
		{
			_tcpListener = new TcpListener(IPAddress.Any, 80);
			_tcpListener.Start();
		}

		public CoolWebServer Add(IHandler handler)
		{
			_handlers.Add(handler);
			return this;
		}

		public void Dispose()
		{
			_tcpListener.Stop();
		}

		public void Start()
		{
			while (true)
			{
				var client = _tcpListener.AcceptTcpClient();
				Task.Run(() => Process(client));
			}
		}

		private void Process(TcpClient client)
		{
			using (client)
			{
				using (var stream = client.GetStream())
				{
					var reader = new StreamReader(stream);
					string line;
					StringBuilder stringBuilder = new StringBuilder();
					do
					{
						line = reader.ReadLine();
						stringBuilder.AppendLine(line);
					} while (!string.IsNullOrEmpty(line));

					var context = new WebContext();
					context.Request.RawRequest = stringBuilder.ToString();
					foreach (var item in _handlers)
					{
						if (item.Handle(context))
							break;
					}

					var writer = new StreamWriter(stream);
					writer.Write(context.Response.Content);
					writer.Flush();
				}
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var server = new CoolWebServer();
			//server.Add(new RequestHandler())
			//	.Add(new StaticFileHandler())
			//	.Add(new MvcHandler())
			//	.Add(new ErrorHandler());
			server.Start();
		}
	}
}