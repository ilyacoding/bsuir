using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> GoodList { get; set; }
        public List<int> CategoryList { get; set; }

        public User(string name, int A_I)
        {
            Id = A_I;
            Name = name;
            GoodList = new List<int>();
            CategoryList = new List<int>();
        }
    }
}
