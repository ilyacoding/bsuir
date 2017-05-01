using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDB.Objects
{
    public class Post
    {
        public Post()
        {
            Categories = new List<Category>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
