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
        public int UserId { get; set; }

        public Good(string name, int userId, int A_I)
        {
            Id = A_I;
            Name = name;
            UserId = userId;
        }
    }
}
