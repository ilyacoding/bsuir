using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{

    public partial class Form1 : Form
    {
        Socket sock;
        public Form1()
        {
            InitializeComponent();
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint localIP = new IPEndPoint(IPAddress.Parse(GetLocalIPAddress()), 7777);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
            sock.Bind(localIP);
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[256];
            string str;

            sock.Receive(data);
            str = Encoding.ASCII.GetString(data);

            if (str.Length > 0)
            {
                label1.Text = str;
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1_Click(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
