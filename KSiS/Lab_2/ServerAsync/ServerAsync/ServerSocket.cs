using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerAsync
{
    class ServerSocket
    {
        private Socket server { get; set; }
        public List<Socket> list { get; set; }

        public ServerSocket(int port)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(GetLocalIP(), port));
            server.Listen(20);
            list = new List<Socket>(0);
        }
        
        public async Task Run()
        {
            while (true)
            {
                var client = await AcceptAsync();
                list.Add(client);
            }
        }

        Task<Socket> AcceptAsync()
        {
            return Task<Socket>.Factory.FromAsync(server.BeginAccept, server.EndAccept, null);
        }


        public IPAddress GetLocalIP()
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
