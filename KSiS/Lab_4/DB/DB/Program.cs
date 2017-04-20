using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    /*
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }*/


    internal class Program
    {
        private static void Main(string[] args)
        {
            var context = new BlogDatabaseEntities();
            context.User.Add(new User() {Id = 0, Name = "good"});
            context.SaveChanges();

            var usr = context.User.ToList();

            foreach (var user in usr)
            {
                Console.WriteLine(user.Name);
            }
            Console.ReadKey();
        }
    }
}
