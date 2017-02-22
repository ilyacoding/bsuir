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
        private UServer serv { get; set; }

        public FormServer()
        {
            InitializeComponent();
            serv = new UServer(IPAddress.Broadcast, 7777);
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            var Date = DateTime.Now.ToString();
            labelDate.Text = Date;
            serv.Send(Date);
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
