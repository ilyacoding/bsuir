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

    public partial class FormClient : Form
    {
        Socket sock;
        public FormClient()
        {
            InitializeComponent();
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            try
            {
                IPEndPoint localIP = new IPEndPoint(GetLocalIP(), 7777);
                labelIP.Text = GetLocalIP().ToString();
                sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
                sock.Bind(localIP);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static IPAddress GetLocalIP()
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

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[256];
            string str;

            sock.Receive(data);
            str = Encoding.ASCII.GetString(data);

            if (str.Length > 0)
            {
                labelDate.Text = str;
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1_Click(sender, e);
        }
    }
}
