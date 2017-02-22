using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerAsync
{
    class Program
    {
        static TServer serv { get; set; }
        public static string data = null;
        static void Main(string[] args)
        {
            byte[] bytes = new Byte[1024];

            serv = new TServer(7777);
            serv.sock.Listen(100);

            // Start listening for connections.
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                Socket handler = serv.sock.Accept();
                data = null;

                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                // Show the data on the console.
                Console.WriteLine("Text received : {0}", data);

                // Echo the data back to the client.
                byte[] msg = Encoding.ASCII.GetBytes(data);

                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
        }
    }
}
