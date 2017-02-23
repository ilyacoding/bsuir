using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{

    public class Server
    {

        public static string data = null;
        public static int ClientCount = 0;
        
        public void StartListening()
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 17777);
            
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    Socket handler = listener.Accept();
                    Console.WriteLine("Connected: {0} clients.", ++ClientCount);
                    RunBackground(handler);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public void RunBackground(Socket handler)
        {
            Thread newThread = new Thread(HandleClient);
            newThread.Start(handler);
        }

        public void HandleClient(Object obj)
        {
            Socket handler = (Socket)obj;
            while (true)
            {
                byte[] bytes = new Byte[1024];
                string data;

                int bytesRec = handler.Receive(bytes);
                data = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                Console.WriteLine("Text received : {0}", data);

                byte[] msg = Encoding.ASCII.GetBytes(Reverse(data));

                handler.Send(msg);
            }
            //handler.Shutdown(SocketShutdown.Both);
            //handler.Close();
        }

        public static int Main(String[] args)
        {

            StartListening();
            return 0;
        }

        public static string Reverse(string text)
        {
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
