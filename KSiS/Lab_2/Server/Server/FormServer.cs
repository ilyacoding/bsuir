using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public partial class FormServer : Form
    {
        private TCPServer server { get; set; }

        public FormServer()
        {
            InitializeComponent();
            server = new TCPServer(17777);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            server.StartAccepting();
            labelOnline.Text = "Server: Online";
            labelIP.Text = "IP: " + server.GetIP().ToString();
            timerClients.Enabled = true;
        }
        
        private void timerClients_Tick(object sender, EventArgs e)
        {
            labelConnected.Text = "Connected: " + server.ClientsConnected;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            server.EndAccepting(); labelOnline.Text = "Server: Offline";
            labelIP.Text = "IP: 255.255.255.255";
            timerClients.Enabled = false;
            labelConnected.Text = "Connected: OFFLINE";

        }
    }
}
