using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CrudWebApi.Models;

namespace CrudWebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        private BlogContext db = new BlogContext();

        // GET: api/Categories
        public IList<CategoryDto> GetCategories()
        {
            return db.Categories.Select(x => new CategoryDto
            {
                Id = x.Id,
                Title = x.Title,
                Posts = x.Posts.ToList()
            }).ToList();
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            var category = db.Categories.Select(x => new CategoryDto
            {
                Id = x.Id,
                Title = x.Title,
                Posts = x.Posts.ToList()
            }).ToList().Find(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category newCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newCategory.Id)
            {
                return BadRequest();
            }

            try
            {
                var category = db.Categories.Include(x => x.Posts).Single(x => x.Id == id);

                db.Entry(category).CurrentValues.SetValues(newCategory);

                foreach (var post in category.Posts.ToList())
                {
                    // ReSharper disable once SimplifyLinqExpression
                    if (!newCategory.Posts.Any(x => x.Id == post.Id))
                    {
                        category.Posts.Remove(post);
                    }
                }

                foreach (var post in newCategory.Posts)
                {
                    if (category.Posts.Any(x => x.Id == post.Id)) continue;
                    db.Posts.Attach(post);
                    category.Posts.Add(post);
                }
                
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = db.Categories.Include(x => x.Posts).Single(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            
            category.Posts = null;

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }
    }
}