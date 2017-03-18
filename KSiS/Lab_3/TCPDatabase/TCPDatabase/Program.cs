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


            ICommand cmd;
            cmd = new AddUser();

            string json = JsonConvert.SerializeObject(cmd, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });

            // Передача json

            ICommand rec = JsonConvert.DeserializeObject<ICommand>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            Data.Data data = new Data.Data();
            
            string TypeMethod = rec.GetType().ToString().Split('.')[1];
            MethodInfo m = data.GetType().GetMethod(TypeMethod);
            m.Invoke(data, new object[] { 5, 5 });

            Console.WriteLine(rec.GetType().ToString());
            Console.ReadKey();
            //new TCPServer(7777);
        }
    }
}
