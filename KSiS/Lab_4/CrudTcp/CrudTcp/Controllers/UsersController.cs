using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using CrudTcp.Core.Http.Action;
using CrudTcp.Models;

namespace CrudTcp.Controllers
{
    public class UsersController : IController
    {
        private BlogContext db = new BlogContext();

        //private IList<IDto> Read<T>(DbSet<T> db) where T : class
        //{
        //    var list = new List<IDto>();
        //    var dtoType = Type.GetType(typeof(T) + "Dto");
        //    foreach (var entry in db)
        //    {
        //        var dto = Activator.CreateInstance(dtoType);
        //
        //        foreach (var entryProperty in entry.GetType().GetProperties())
        //        {
        //            foreach (var dtoProperty in dto.GetType().GetProperties())
        //            {
        //                if (dtoProperty.Name != entryProperty.Name) continue;
        //
        //                if (dtoProperty.PropertyType.GetInterface("ICollection") != null)
        //                {
        //
        //                }
        //                else
        //                {
        //                    dtoProperty.SetValue(dto, entryProperty.GetValue(entry));
        //                }
        //            }
        //        }
        //        list.Add(dto as IDto);
        //    }
        //    return list;
        //}

        // GET: api/Users
        public IHttpAction GetUsers()
        {
            db = new BlogContext();
            return new Ok(db.Users.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Reviews = x.Reviews.ToList() 
            }).ToList());
        }
        
        // GET: api/Users/5
        public IHttpAction GetUser(int id)
        {
            db = new BlogContext();
            var user = db.Users.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Reviews = x.Reviews.ToList()
            }).ToList().Find(x => x.Id == id);
        
            if (user == null)
            {
                return new NotFound();
            }
        
            return new Ok(user);
        }
        
        // PUT: api/Users/5
        public IHttpAction PutUser(int id, User newUser)
        {
            db = new BlogContext();
            if (id != newUser.Id)
            {
                return new BadRequest();
            }
        
            try
            {
                var user = db.Users.Include(x => x.Reviews).Single(x => x.Id == id);
        
                db.Entry(user).CurrentValues.SetValues(newUser);
        
                foreach (var review in user.Reviews.ToList())
                {
                    // ReSharper disable once SimplifyLinqExpression
                    if (!newUser.Reviews.Any(x => x.Id == review.Id))
                    {
                        user.Reviews.Remove(review);
                    }
                }
        
                foreach (var review in newUser.Reviews)
                {
                    if (user.Reviews.Any(x => x.Id == review.Id)) continue;
                    db.Reviews.Attach(review);
                    user.Reviews.Add(review);
                }
        
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return new NotFound();
                }
                else
                {
                    return new BadRequest();
                }
            }
            return new NoContent();
        }
        
        // POST: api/Users
        public IHttpAction PostUser(User user)
        {
            db = new BlogContext();
            db.Users.Add(user);
            db.SaveChanges();
        
            return new Created(user);//CreatedAtRoute("DefaultApi", new {id = user.Id}, user);
        }
        
        // DELETE: api/Users/5
        public IHttpAction DeleteUser(int id)
        {
            db = new BlogContext();
            User user;
            if (UserExists(id))
            {
                user = db.Users.Include(x => x.Reviews).Single(x => x.Id == id);
            }
            else
            {
                return new NotFound();
            }

            user.Reviews = null;
        
            db.Users.Remove(user);
            db.SaveChanges();
        
            return new Ok(user);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}