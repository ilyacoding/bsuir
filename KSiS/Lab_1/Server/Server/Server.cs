using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class UServer
    {
        private Socket sock { get; set; }
        private IPEndPoint toIP { get; set; }
        
        public UServer(IPAddress IP, int port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.EnableBroadcast = true;
            toIP = new IPEndPoint(IP, port);
        }
        
        public void Send(string Message)
        {
            sock.SendTo(Encoding.ASCII.GetBytes(Message), toIP);
        }
    }
}
