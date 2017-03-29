using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> CategoryList { get; set; }

        public Good(string name, int A_I)
        {
            Id = A_I;
            Name = name;
            CategoryList = new List<int>();
        }
    }
}
