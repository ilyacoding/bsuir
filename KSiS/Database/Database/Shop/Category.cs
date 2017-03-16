using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Shop
{
    public class Category
    {
        public static int A_I = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> GoodList { get; set; }

        public Category(string name)
        {
            Id = ++A_I;
            Name = name;
            GoodList = new List<int>();
        }
    }
}