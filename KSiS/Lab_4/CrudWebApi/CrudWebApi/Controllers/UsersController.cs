using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using CrudWebApi.Models;

namespace CrudWebApi.Controllers
{
    public class UsersController : ApiController
    {
        private BlogContext db = new BlogContext();

        private IList<IDto> Read<T>(DbSet<T> db) where T : class
        {
            var list = new List<IDto>();
            var dtoType = Type.GetType(typeof(T) + "Dto");
            foreach (var entry in db)
            {
                var dto = Activator.CreateInstance(dtoType);
        
                foreach (var entryProperty in entry.GetType().GetProperties())
                {
                    foreach (var dtoProperty in dto.GetType().GetProperties())
                    {
                        if (dtoProperty.Name != entryProperty.Name) continue;
        
                        if (dtoProperty.PropertyType.GetInterface("ICollection") != null)
                        {
                            
                        }
                        else
                        {
                            dtoProperty.SetValue(dto, entryProperty.GetValue(entry));
                        }
                    }
                }
                list.Add(dto as IDto);
            }
            return list;
        }

        // GET: api/Users
        public IList<UserDto> GetUsers()
        {
            return db.Users.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Reviews = x.Reviews.ToList()
            }).ToList();
            //return Read(db.Users);
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            var user = db.Users.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Reviews = x.Reviews.ToList()
            }).ToList().Find(x => x.Id == id);
      
            if (user == null)
            {
                return NotFound();
            }
      
            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newUser.Id)
            {
                return BadRequest();
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
                    db.Reviews.AddOrUpdate(review);
                    user.Reviews.Add(review);
                }

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}