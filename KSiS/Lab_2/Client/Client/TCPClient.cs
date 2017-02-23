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
    public class TCPClient
    {
        private IPEndPoint serverIE { get; set; }
        private Socket sock { get; set; }
        private bool Connected { get; set; }

        public TCPClient(IPAddress remoteIP, int port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverIE = new IPEndPoint(remoteIP, port);
        }

        public EndPoint GetIE()
        {
            return sock.RemoteEndPoint;
        }

        public bool Connect()
        {
            try
            {
                sock.Connect(serverIE);
                Connected = true;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public int Send(string msg)
        {
            if (Connected)
            {
                return sock.Send(Encoding.ASCII.GetBytes(msg));
            }
            else
            {
                return 0;
            }
        }

        public string Receive()
        {
            if (Connected)
            {
                byte[] bytes = new byte[1024];
                int bts = sock.Receive(bytes);
                return Encoding.ASCII.GetString(bytes);
            }

            return "";
        }

        public void Close()
        {
            if (Connected)
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
                Connected = false;
            }
        }
    }
}
