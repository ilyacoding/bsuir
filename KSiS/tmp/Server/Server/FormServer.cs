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
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private UServer serv { get; set; }

        public class StateObject
        {
            public Socket workSocket = null;
            public byte[] buffer = new byte[256];
        }

        public FormServer()
        {
            InitializeComponent();
            serv = new UServer(7777);
            serv.sock.Listen(10);
            labelIP.Text = "IP: " + serv.GetLocalIP().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Socket handler = serv.sock.Accept();
            serv.sock.BeginAccept(new AsyncCallback(AcceptCallback), serv.sock);
            /*byte[] bytes = new byte[1024];
            handler.Receive(bytes);
            if (bytes.Length > 0)
            {
                labelInfo.Text = Encoding.ASCII.GetString(bytes);
                handler.Send(Encoding.ASCII.GetBytes(Reverse(labelInfo.Text)));
            }*/
        }

        public void AcceptCallback(IAsyncResult AsyncCall)
        {
            allDone.Set();
            Socket listener = (Socket)AsyncCall.AsyncState;
            Socket handler = listener.EndAccept(AsyncCall);

            StateObject state = new StateObject();
            state.workSocket = handler;

            handler.BeginReceive(state.buffer, 0, state.buffer.Length, 0, new AsyncCallback(ReceiveCallback), state);
        }

        public void ReceiveCallback(IAsyncResult AsyncCall)
        {
            StateObject state = (StateObject)AsyncCall.AsyncState;
            Socket handler = state.workSocket;
 
            int bytesRead = handler.EndReceive(AsyncCall);

            if (bytesRead > 0)
            {
                string message = Encoding.ASCII.GetString(state.buffer);
                message = Reverse(message);
                byte[] data = Encoding.ASCII.GetBytes(message);//;

                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() => richTextBoxConsole.AppendText("Client " + handler.RemoteEndPoint.ToString() + " connected.\n")));
                    BeginInvoke(new Action(() => richTextBoxConsole.AppendText("Message: " + message + " received.\n\n")));
                }
                else
                {
                    richTextBoxConsole.AppendText("Client " + handler.RemoteEndPoint.ToString() + " connected.\n");
                    richTextBoxConsole.AppendText("Message: " + message + " received.\n\n");
                }

                handler.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), handler);
            }
        }

        private void Send(Socket handler, string data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        public void SendCallback(IAsyncResult AsyncCall)
        {
            Socket handler = (Socket)AsyncCall.AsyncState;
            int bytes = handler.EndSend(AsyncCall);
            if (bytes > 0)
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() => richTextBoxConsole.AppendText("Send " + bytes.ToString() + " bytes to client.\n")));
                }
                else
                {
                    richTextBoxConsole.AppendText("Send " + bytes.ToString() + " bytes to client.\n");
                }
            }

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        public static string Reverse(string text)
        {
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
