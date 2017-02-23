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
        private TCPClient client { get; set; }

        public FormClient()
        {
            InitializeComponent();
            client = new TCPClient(IPAddress.Parse(textBoxIP.Text), 17777);
        }      

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            client = new TCPClient(IPAddress.Parse(textBoxIP.Text), 17777);
            if (client.Connect())
            {
                labelConnected.Text = "Connected to " + client.GetIE().ToString();
            }
            else
            {
                MessageBox.Show("Can't connect to server.");
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            client.Send(textBoxMessage.Text);
            textBoxResponse.Text = client.Receive();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            client.Close();
        }
        
    }
}
