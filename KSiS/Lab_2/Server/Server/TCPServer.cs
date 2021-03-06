﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class TCPServer
    {
        public int ClientsConnected = 0;
        public Socket sock { get; set; }
        private IPEndPoint localIP { get; set; }
        private Thread Tasker { get; set; }
        
        public TCPServer(int port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            localIP = new IPEndPoint(GetLocalIP(), port);
            Tasker = new Thread(AcceptBackground);
            sock.Bind(localIP);
            sock.Listen(10);
        }

        public void StartAccepting()
        {
            Tasker = new Thread(AcceptBackground);
            Tasker.Start();
        }

        public void EndAccepting()
        {
            Tasker.Suspend();
        }

        public void AcceptBackground()
        {
            while (true)
            {
                Socket handler = sock.Accept();
                RunBackground(handler);
            }
        }

        public void RunBackground(Socket handler)
        {
            Thread newThread = new Thread(HandleClient);
            newThread.Start(handler);
            ClientsConnected++;
        }

        public void HandleClient(Object obj)
        {
            Socket handler = (Socket)obj;
            while (true)
            {
                try {
                    byte[] bytes = new Byte[1024];
                    string data;

                    int bytesRec = handler.Receive(bytes);
                    data = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    char[] array = data.ToCharArray();
                    Array.Reverse(array);
                    data = new string(array);

                    byte[] msg = Encoding.UTF8.GetBytes(data);

                    handler.Send(msg);
                }
                catch (Exception e)
                {
                    ClientsConnected--;
                    break;
                }
            }
        }

        public void Send(string Message)
        {
            if (sock.Connected)
                sock.Send(Encoding.UTF8.GetBytes(Message));
        }

        public IPAddress GetIP()
        {
            return localIP.Address;
        }
        
        private IPAddress GetLocalIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}
