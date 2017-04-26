using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDB.Objects
{
    public class Category
    {
        public Category()
        {
            Posts = new List<Post>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
