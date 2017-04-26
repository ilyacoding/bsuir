using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDB;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BlogRepository(new BlogDatabaseContainer());
            
//          foreach (var el in db.ReadAll<User>())
//          {
//              Console.WriteLine(el.Id + " " + el.Name);
//              foreach (var element in el.Review)
//              {
//                  Console.WriteLine("- " + element.Id + " " + element.Content);
//              }
//          }
            var x = db.ReadAll<Post>();

            foreach (var el in x)
            {
                Console.WriteLine(el.Id + " " + el.Title);
                foreach (var eell in el.Category)
                {
                    Console.WriteLine(eell.Id + " " + eell.Title);
                }
            }

            Console.ReadKey();
        }
    }
}
