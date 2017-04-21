using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDatabase;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BlogRepository(new BlogDatabaseContainer());
            db.Create<User>(new User() { Name = "Ilya" });
            //db.BlogDatabase.UserSet.Add(new User() {Name = "Ilya"});
            //db.BlogDatabase.SaveChanges();
            //var c = db.RetreiveAll<User>();
            foreach (var el in db.RetreiveAll<User>())
            {
                Console.WriteLine(el.Name);
            }
            Console.ReadKey();
        }
    }
}
