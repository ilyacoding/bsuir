using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace TCPClient
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
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public int Send(string msg)
        {
            if (Connected)
            {
                return sock.Send(Encoding.UTF8.GetBytes(msg));
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
                string buf = "";
                int BytesReceived;
                do
                {
                    BytesReceived = sock.Receive(bytes);
                    buf += Encoding.UTF8.GetString(bytes);
                } while (BytesReceived > 0);
                return buf;
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