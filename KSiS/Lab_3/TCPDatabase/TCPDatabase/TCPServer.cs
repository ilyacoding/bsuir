using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Command;
using Database;

namespace TCPDatabase
{
    public class TcpServer
    {
        private TcpListener Server { get; }
        private Thread Tasker { get; set; }
        
        private HandlersRegistry Registry { get; }

        private Serializer.Serializer Serializer { get; }

        public TcpServer(int port, HandlersRegistry reg, Serializer.Serializer serializer)
        {
            Serializer = serializer;
            Registry = reg;

            Server = new TcpListener(GetLocalIp(), port);
            Server.Start();
            StartAccepting();

            Console.WriteLine("Server started at " + Server.LocalEndpoint);

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
                var handler = Server.AcceptTcpClient();
                Console.WriteLine("Client " + handler.Client.RemoteEndPoint + " connected.");
                RunBackground(handler);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        public void RunBackground(TcpClient handler)
        {
            var newThread = new Thread(HandleClient);
            newThread.Start(handler);
        }

        public void HandleClient(object obj)
        {
            var client = (TcpClient)obj;
            while (true)
            {
                try
                {
                    var stream = client.GetStream();

                    var buffer = new byte[256];
                    var data = "";

                    while (stream.DataAvailable || data.Length == 0)
                    {
                        var bytesRead = stream.Read(buffer, 0, buffer.Length);
                        data += Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    }
                    
                    var command = Serializer.Deserialize(data);
                    var handler = Registry.Get(command.GetType());
                    var response = handler.Execute(command);
                    var serializedResponse = Serializer.Serialize(new Response { Value = response });
                    var bytesResponse = Encoding.UTF8.GetBytes(serializedResponse);

                    stream.Write(bytesResponse, 0, bytesResponse.Length);
                }
                catch (Exception)
                {
                    Console.WriteLine("Client " + client.Client.RemoteEndPoint + " disconnected.");
                    break;
                }
            }
        }

        private static IPAddress GetLocalIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
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
