using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command;
using Database;
using Newtonsoft.Json;
using System.Reflection;

namespace TCPDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Database.Database();

            var registry = new HandlersRegistry();
            registry.Reg(new AddGood().GetType(), new AddGoodCommandHandler(db));
            registry.Reg(new AddCategory().GetType(), new AddCategoryCommandHandler(db));
            registry.Reg(new AddUser().GetType(), new AddUserCommandHandler(db));

            new TCPServer(17777, registry, new Serializer.Serializer());
            Console.ReadKey();
        }
    }
}