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
        public IPEndPoint localIP { get; set; }
        public IPEndPoint serverIP { get; set; }
        public Socket sock { get; set; }

        public UClient(IPAddress remoteIP, int port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPEndPoint localIP = new IPEndPoint(GetLocalIP(), port);
            IPEndPoint serverIP = new IPEndPoint(remoteIP, port);
            //sock.Bind(localIP);
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
