using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDB
{
    public class BlogRepository
    {
        private DbContext Database { get; set; }

        public BlogRepository(DbContext database)
        {
            Database = database;
        }

        private void Save()
        {
            Database.SaveChanges();
        }

        private DbSet<T> GetList<T>() where T : class
        {
            return (DbSet<T>)Database.GetType().GetProperty(typeof(T).Name + "Set").GetValue(Database, null);
        }

        public void Create<T>(T element) where T : class
        {
            var list = GetList<T>();
            list.Add(element);
            Save();
        }

        public IQueryable<T> ReadAll<T>() where T : class
        {
            return GetList<T>();
        }

        public T Read<T>(int id) where T : class
        {
            var list = GetList<T>().ToList();
            return list.Find(x => (int)x.GetType().GetProperty("Id").GetValue(x, null) == id);
        }

        public bool Update<T>(T newElement) where T : class
        {
            Database.Entry(newElement).State = EntityState.Modified;

            try
            {
                Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
            //var list = GetList<T>().ToList();
            //var oldElement = list.Find(x => (int)newElement.GetType().GetProperty("Id").GetValue(newElement, null) == (int)x.GetType().GetProperty("Id").GetValue(x, null));
            //if (oldElement == null) throw new Exception("No such element");
            //
            //foreach (var oldProperty in oldElement.GetType().GetProperties())
            //{
            //    foreach (var newProperty in newElement.GetType().GetProperties())
            //    {
            //        if (oldProperty.Name == newProperty.Name)
            //        {
            //            oldProperty.SetValue(oldElement, newProperty.GetValue(newElement, null));
            //        }
            //    }
            //}
            //Save();
        }

        public void Delete<T>(T element) where T : class
        {
            var list = GetList<T>();
            if (element != null) list.Remove(element);
            Save();
        }
    }
}
