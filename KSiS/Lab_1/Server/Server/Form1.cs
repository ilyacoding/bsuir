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

namespace Server
{
    public partial class Form1 : Form
    {
        Socket sock;
        public Form1()
        {
            InitializeComponent();

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            byte[] data = Encoding.ASCII.GetBytes(label1.Text);
            IPEndPoint toIP = new IPEndPoint(IPAddress.Broadcast, 7777);
            //string IPBroad = "25.87.255.255";
            //IPEndPoint toIP = new IPEndPoint(IPAddress.Parse(IPBroad), 7777);
            label2.Text = IPAddress.Broadcast.ToString();
            sock.SendTo(data, toIP);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
