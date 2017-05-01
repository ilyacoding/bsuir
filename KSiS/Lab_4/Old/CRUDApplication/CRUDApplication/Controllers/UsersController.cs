using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BlogDB;
using BlogDB.Objects;

namespace CRUDApplication.Controllers
{
    public class UsersController : ApiController
    {
        private BlogRepository db = new BlogRepository(new BlogContext());
        private BlogContext _db = new BlogContext()
        {
            Configuration = { ProxyCreationEnabled = false, LazyLoadingEnabled = false }
        };
        
        // GET: api/Users
        public IEnumerable<User> GetUserSet()
        {
            //return blogRepository.ReadAll<User>();

            return db.ReadAll<User>();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            var user = db.Read<User>(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            if (db.Update(user))
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw new Exception();
            }
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(user);

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            var user = db.Read<User>(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Delete<User>(user);

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return db.ReadAll<User>().Count(e => e.Id == id) > 0;
        }
    }
}