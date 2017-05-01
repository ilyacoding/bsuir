using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDB.Objects
{
    public class Review
    {
        public Review()
        {
            
        }

        public int Id { get; set; }
        public string Content { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
