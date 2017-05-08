using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CrudTcp.Core
{
    public class TcpServer
    {
        public const string HttpVersion = "HTTP/1.1";

        private TcpListener Server { get; }
        private Task Task { get; }
        private ControllerHandler ControllerHandler { get; }

        public TcpServer(string ip, int port, ControllerHandler controllerHandler)
        {
            ControllerHandler = controllerHandler;
            Server = new TcpListener(IPAddress.Parse(ip), port);
            Task = new Task(AcceptBackground);
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
                Console.WriteLine("-> Client" + client.Client.RemoteEndPoint + " connected.");
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
                    var response = ControllerHandler.Execute(strRequest);
                    //Console.WriteLine(Encoding.UTF8.GetString(response));
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
