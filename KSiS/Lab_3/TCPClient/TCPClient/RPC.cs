using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Data;
using Command;
using Newtonsoft.Json;

namespace TCPClient
{
    public class RPC
    {
        private TcpClient client { get; set; }
        private NetworkStream stream { get; set; }

        public RPC()
        {
            client = new TcpClient();
        }
        
        public bool Connect(string remoteIP, int port)
        {
            try
            {
                client.Connect(remoteIP, port);
                stream = client.GetStream();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Connected()
        {
            return client.Connected;
        }

        public void Send(string msg)
        {
            if (client.Connected)
            {
                byte[] buf = Encoding.UTF8.GetBytes(msg);
                stream.Write(buf, 0, buf.Length);
            }
        }

        public string Receive()
        {
            string msg = "";
            if (client.Connected)
            {
                byte[] buffer = new byte[256];
                while (stream.DataAvailable || msg.Length == 0)
                {
                    int BytesRead = stream.Read(buffer, 0, buffer.Length);
                    msg += Encoding.UTF8.GetString(buffer, 0, BytesRead);
                }
            }
            return msg;
        }

        public object ProcessFunctuion(ICommand cmd, object[] parameters)
        {
            cmd.array = parameters;
            string json = JsonConvert.SerializeObject(cmd, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });

            Send(json);
            json = Receive();

            Response response = JsonConvert.DeserializeObject<Response>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            return response.value;
        }
    }
}
