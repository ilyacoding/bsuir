using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDB.Objects
{
    public class User
    {
        public User()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
