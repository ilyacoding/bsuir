using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDatabase
{
    public class BlogRepository
    {
        public BlogDatabaseContainer BlogDatabaseContainer { get; set; }

        public BlogRepository(BlogDatabaseContainer blogDatabaseContainer)
        {
            BlogDatabaseContainer = blogDatabaseContainer;
            BlogDatabaseContainer.Configuration.LazyLoadingEnabled = false;
        }

        public void Save()
        {
            BlogDatabaseContainer.SaveChanges();
        }

        public ICollection<T> GetAll<T>()
        {
            return (ICollection<T>)BlogDatabaseContainer.GetType().GetField(typeof(T) + "Set").GetValue(null);
        }
    }
}
