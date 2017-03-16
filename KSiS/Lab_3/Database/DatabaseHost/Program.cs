using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace DatabaseHost
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(Database.Database)))
            {
                host.Open();
                Console.WriteLine("Host is running");
                Console.ReadKey();
            }
        }
    }
}
