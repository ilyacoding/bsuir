using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Shop;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Database("db.txt");

            /*db.AddCategory("Мобильные телефоны");
            db.AddCategory("Компьютеры");
            db.AddCategory("Спорт");

            db.AddCatToGood(db.AddGood("Nokia"), 1);
            db.AddCatToGood(db.AddGood("HTC"), 1);
            db.AddCatToGood(db.AddGood("Samsung"), 1);
            db.AddCatToGood(db.AddGood("Apple"), 1);
            db.AddCatToGood(4, 2);

            db.AddCatToGood(db.AddGood("Asus"), 2);
            db.AddCatToGood(db.AddGood("Lenovo"), 2);
            db.AddCatToGood(db.AddGood("DELL"), 2);
            db.AddCatToGood(db.AddGood("Sony"), 2);


            db.AddCatToGood(db.AddGood("Волебольный мяч"), 3);
            db.AddCatToGood(db.AddGood("Велосипед"), 2);
            db.AddCatToGood(db.AddGood("Коньки"), 3);
            

            db.AddUser("Илья");
            db.AddGoodToUser(1, 1);
            db.AddCatToUser(1, 2);
            db.AddCatToUser(1, 1);

            db.AddUser("Коля");
            db.AddGoodToUser(2, 3);
            db.AddGoodToUser(2, 5);
            db.AddGoodToUser(2, 6);
            db.AddCatToUser(2, 1);
            db.AddCatToUser(2, 3);

            db.AddUser("Маша");
            db.AddGoodToUser(3, 1);
            db.AddGoodToUser(2, 2);
            db.AddGoodToUser(2, 4);
            db.AddCatToUser(3, 1);

            db.SaveTo("db.txt");*/

            db.Load();

            var response = db.GetData();
            foreach (var x in response.UserList)
            {
                Console.WriteLine("-----> id:" + x.Id + " name:" + x.Name);
                Console.WriteLine("Category:");
                foreach (var p in x.CategoryList)
                {
                    Console.WriteLine("> id:" + p);
                }
                Console.WriteLine("Goods:");
                foreach (var p in x.GoodList)
                {
                    Console.WriteLine("> id:" + p);
                }
            }
            
            Console.WriteLine("");

            foreach (var x in response.CategoryList)
            {
                Console.WriteLine("-----> id:" + x.Id + " name:" + x.Name);
                Console.WriteLine("Goods:");
                foreach (var p in x.GoodList)
                {
                    Console.WriteLine("> id:" + p);
                }
            }

            Console.WriteLine("");

            foreach (var x in response.GoodList)
            {
                Console.WriteLine("-----> id:" + x.Id + " name:" + x.Name);
                Console.WriteLine("Category:");
                foreach (var p in x.CategoryList)
                {
                    Console.WriteLine("> id:" + p);
                }
            }

            Console.ReadKey();
        }
    }
}
