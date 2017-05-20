using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CrudTcp.Core.Http;

namespace CrudTcp.Core
{
    public class TcpServer
    {
        public const string HttpVersion = "HTTP/1.1";

        private TcpListener Server { get; }
        private Task Task { get; }

        private ControllersRegistry ControllersRegistry { get; set; }
        private SerializerRegistry SerializerRegistry { get; set; }

        public TcpServer(string ip, int port, SerializerRegistry serializerRegistry, ControllersRegistry controllersRegistry)
        {
            Server = new TcpListener(IPAddress.Parse(ip), port);
            Task = new Task(AcceptBackground);

            SerializerRegistry = serializerRegistry;
            ControllersRegistry = controllersRegistry;
        }

        public void Start()
        {
            Server.Start();
            Task.Start();
            Console.WriteLine("Server started at " + Server.LocalEndpoint);
        }

        public void Stop()
        {
            //   Task.Dispose();
        }

        public void AcceptBackground()
        {
            while (true)
            {
                var client = Server.AcceptTcpClient();
                Console.WriteLine("-> Request from " + client.Client.RemoteEndPoint);
                Task.Factory.StartNew(() => HandleClient(client));
            }
        }

        public void HandleClient(TcpClient client)
        {
            var stream = client.GetStream();
            while (true)
            {
                try
                {
                    var strRequest = Receive(stream);

                    var httpServer = new HttpServer(ControllersRegistry, SerializerRegistry);
                    var httpResponse = httpServer.Execute(strRequest);
                    var response = httpServer.GetResponse(httpResponse);

                    Send(stream, response);
                    client.Close();
                    break;
                }
                catch (Exception e)
                {
                    client.Close();
                    Console.WriteLine(e.ToString());
                    break;
                }
            }
        }

        public string Receive(NetworkStream stream)
        {
            var buffer = new byte[256];
            var data = "";

            while (stream.DataAvailable || data.Length == 0)
            {
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                data += Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }

            return data;
        }

        public void Send(NetworkStream stream, byte[] msg)
        {
            stream.Write(msg, 0, msg.Length);
        }
    }
}
