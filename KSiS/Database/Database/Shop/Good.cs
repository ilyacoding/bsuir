using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Shop
{
    public class Good
    {
        public static int A_I = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> CategoryList { get; set; }

        public Good(string name)
        {
            Id = ++A_I;
            Name = name;
            CategoryList = new List<int>();
        }
    }
}
