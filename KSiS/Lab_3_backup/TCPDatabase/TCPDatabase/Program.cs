using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command;
using Newtonsoft.Json;
using System.Reflection;

namespace TCPDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            new TCPServer(17777);
            Console.ReadKey();
        }
    }
}
