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
    public partial class FormServer : Form
    {
        Socket sock;
        public FormServer()
        {
            InitializeComponent();
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            try
            {
                sock.DontFragment = true;
                sock.EnableBroadcast = true;
                sock.MulticastLoopback = false;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error initializing sockets.");
            }
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDate.Text = DateTime.Now.ToString();
            byte[] data = Encoding.ASCII.GetBytes(labelDate.Text);
            IPEndPoint toIP = new IPEndPoint(IPAddress.Broadcast, 7777);
            labelIP.Text = "IP: " + IPAddress.Broadcast.ToString();
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
