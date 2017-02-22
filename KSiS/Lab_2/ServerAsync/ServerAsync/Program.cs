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
        static ServerSocket serv { get; set; }
        public static string data = null;

        static void Main(string[] args)
        {
            byte[] bytes = new Byte[1024];

            serv = new ServerSocket(7777);
            while (true)
            {
                serv.Run();
                if (serv.list.Count > 0)
                {
                    foreach (var client in serv.list.ToArray())
                    {
                        byte[] data = new byte[256];
                        client.Receive(data);
                        Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
                        string response = "good_string";// Reverse(Encoding.ASCII.GetString(data, 0, data.Length));
                        byte[] sendData = Encoding.ASCII.GetBytes(response);
                        Console.WriteLine(Encoding.ASCII.GetString(sendData));

                        client.Send(sendData);

                        client.Shutdown(SocketShutdown.Both);
                        serv.list.Remove(serv.list.Last());
                        client.Dispose();
                    }
                }

                Console.WriteLine("Connected: " + serv.list.Count + " clients.");
            }

            // Start listening for connections.
            /*while (true)
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
            }*/
        }

        public static string Reverse(string text)
        {
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
