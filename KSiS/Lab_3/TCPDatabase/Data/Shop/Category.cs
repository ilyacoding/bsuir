using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Category
    {
        public static int A_I = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public Category(string name, int userId, int A_I)
        {
            Id = A_I;
            Name = name;
            UserId = userId;
        }
    }
}
