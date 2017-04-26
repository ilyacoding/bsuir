using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDB.Objects;

namespace BlogDB
{
    public class BlogContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<User> UserSet { get; set; }
        public DbSet<Category> CategorySet { get; set; }
        public DbSet<Review> ReviewSet { get; set; }
        public DbSet<Post> PostSet { get; set; }
        //public DbSet<PostCategory> PostCategorySet { get; set; }
    }
}
