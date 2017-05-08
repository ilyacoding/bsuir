using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudTcp.Controllers;
using CrudTcp.Core;
using CrudTcp.Serialization;

namespace CrudTcp
{
    class Program
    {
        static void Main(string[] args)
        {
            var controllerRegistry = new ControllersRegistry();
            controllerRegistry.Reg("users", new UsersController());

            var serializerRegistry = new SerializerRegistry();
            serializerRegistry.RegDefault(new JsonSerializer());
            serializerRegistry.Reg(new List<string>() {"application/json"}, new JsonSerializer());
            serializerRegistry.Reg(new List<string>() {"application/xml"}, new XmlSerializer());

            var serv = new TcpServer("127.0.0.1", 8000, new ControllerHandler(controllerRegistry, serializerRegistry));
            serv.Start();
            Console.ReadKey();
        }
    }
}
