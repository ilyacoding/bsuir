using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace Client
{
    public class UClient
    {
        private IPEndPoint localIP { get; set; }
        private Socket sock { get; set; }

        public UClient(int port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint localIP = new IPEndPoint(GetLocalIP(), port);
            sock.Bind(localIP);
        }

        public string Receive()
        {
            byte[] data = new byte[256];
            string str = "";

            if (sock.Available > 0)
            {
                sock.Receive(data);
                str += Encoding.ASCII.GetString(data);
            }

            return str;
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
