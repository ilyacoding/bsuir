using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command;
using Newtonsoft.Json;

namespace TCPClient
{
    public partial class FormClient : Form
    {
        private TCPClient client { get; set; }

        public FormClient()
        {
            InitializeComponent();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand cmd = new AddUser();

            string json = JsonConvert.SerializeObject(cmd, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });
            MessageBox.Show(json);
            client.Send(json);
        }
    }
}
