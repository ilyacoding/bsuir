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

namespace Client
{
    public partial class FormClient : Form
    {
        private UClient client { get; set; }

        public FormClient()
        {
            InitializeComponent();
            client = new UClient(7777);
            labelIP.Text = "IP: " + client.GetLocalIP().ToString();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            string str = client.Receive();

            if (str.Length > 0)
            {
                labelDate.Text = str;
            }
        }
    }
}
