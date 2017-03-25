using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using Data;
using Command;
using System.Reflection;
using Database;

namespace TCPDatabase
{
    public class TCPServer
    {
        private TcpListener server { get; set; }
        private Thread Tasker { get; set; }

        private Database.Database db { get; set; }
        private HandlersRegistry registry { get; set; }

        private Serializer.Serializer serializer { get; set; }

        public TCPServer(int port, HandlersRegistry reg, Serializer.Serializer Serializer)
        {
            db = new Database.Database();
            serializer = Serializer;
            registry = reg;

            server = new TcpListener(GetLocalIP(), port);
            server.Start();

            Console.WriteLine("Server started at " + server.LocalEndpoint.ToString());
        }

        public void StartAccepting()
        {
            Tasker = new Thread(AcceptBackground);
            Tasker.Start();
        }

        public void EndAccepting()
        {
            Tasker.Abort();
        }

        public void AcceptBackground()
        {
            while (true)
            {
                TcpClient handler = server.AcceptTcpClient();
                Console.WriteLine("Client " + handler.Client.RemoteEndPoint.ToString() + " connected.");
                RunBackground(handler);
            }
        }

        public void RunBackground(TcpClient handler)
        {
            Thread newThread = new Thread(HandleClient);
            newThread.Start(handler);
        }

        public void HandleClient(Object obj)
        {
            var client = (TcpClient)obj;
            while (true)
            {
                try
                {
                    NetworkStream stream = client.GetStream();

                    byte[] buffer = new byte[256];
                    string data = "";

                    while (stream.DataAvailable || data.Length == 0)
                    {
                        int BytesRead = stream.Read(buffer, 0, buffer.Length);
                        data += Encoding.UTF8.GetString(buffer, 0, BytesRead);
                    }
                    
                    var command = serializer.Deserialize(data);
                    var handler = registry.Get(command.GetType());
                    var response = handler.Execute(command);
                    string serializedResponse = serializer.Serialize(response);

                    stream.Write(Encoding.UTF8.GetBytes(serializedResponse), 0, serializedResponse.Length);
                }
                catch (Exception)
                {
                    Console.WriteLine("Client " + client.Client.RemoteEndPoint.ToString() + " disconnected.");
                    break;
                }
            }
        }

        private IPAddress GetLocalIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}
