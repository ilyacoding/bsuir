using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerAsync
{
    class TServer
    {
        public Socket sock { get; set; }
        public IPEndPoint toIP { get; set; }

        public TServer(int port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localIP = new IPEndPoint(GetLocalIP(), port);
            sock.Bind(localIP);
        }

        public void Send(string Message)
        {
            if (sock.Connected)
                sock.Send(Encoding.ASCII.GetBytes(Message));
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
