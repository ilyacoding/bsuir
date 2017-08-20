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
    internal class Program
    {
        private static void Main(string[] args)
        {
            var controllerRegistry = new ControllersRegistry();
            controllerRegistry.Reg("Users", new UsersController());
            controllerRegistry.Reg("Categories", new CategoriesController());
            controllerRegistry.Reg("Posts", new PostsController());
            controllerRegistry.Reg("Reviews", new ReviewsController());

            var serializerRegistry = new SerializerRegistry();
            serializerRegistry.RegDefault(new JsonSerializer());
            serializerRegistry.Reg(new List<string> {"application/json", "text/json"}, new JsonSerializer());
            serializerRegistry.Reg(new List<string> {"application/xml", "text/xml"}, new XmlSerializer());

            var serv = new TcpServer("127.0.0.1", 8000, serializerRegistry, controllerRegistry);
            serv.Start();
            Console.ReadKey();
        }
    }
}
