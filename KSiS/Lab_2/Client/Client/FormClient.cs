using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class FormClient : Form
    {
        private UClient client { get; set; }

        public FormClient()
        {
            InitializeComponent();
            //labelIP.Text = "IP: " + client.GetLocalIP().ToString();
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            client = new UClient(IPAddress.Parse(textBoxIP.Text), 17777);
            client.sock.Connect(new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 17777));
            labelConnected.Text = "Connected to " + client.sock.RemoteEndPoint.ToString();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            client.sock.Send(Encoding.ASCII.GetBytes(textBoxMessage.Text));
            byte[] bytes = new byte[256];
            int bts = client.sock.Receive(bytes);
            if (bts > 0)
            {
                textBoxResponse.Text = Encoding.ASCII.GetString(bytes);
            }
            else
            {
                MessageBox.Show("Received nothing");
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            client.sock.Close();
        }
        
    }
}
