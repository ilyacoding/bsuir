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
    public class CategoriesController : IController
    {
        private BlogContext db = new BlogContext();

        // GET: api/Categories
        public IHttpAction GetCategories()
        {
            db = new BlogContext();

            return new Ok(db.Categories.Select(x => new CategoryDto
            {
                Id = x.Id,
                Title = x.Title,
                Posts = x.Posts.Select(y => new PostDto()
                {
                    Id = y.Id,
                    Title = y.Title,
                    Content = y.Content
                }).ToList()
            }).ToList());
        }

        // GET: api/Categories/5
        public IHttpAction GetCategory(int id)
        {
            db = new BlogContext();

            var category = db.Categories.Select(x => new CategoryDto
            {
                Id = x.Id,
                Title = x.Title,
                Posts = x.Posts.Select(y => new PostDto()
                {
                    Id = y.Id,
                    Title = y.Title,
                    Content = y.Content
                }).ToList()
            }).ToList().Find(x => x.Id == id);

            if (category == null)
            {
                return new NotFound();
            }

            return new Ok(category);
        }

        // PUT: api/Categories/5
        public IHttpAction PutCategory(int id, Category newCategory)
        {
            db = new BlogContext();

            if (id != newCategory.Id)
            {
                return new BadRequest();
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
                    return new NotFound();
                }
                else
                {
                    return new BadRequest();
                }
            }
            catch (Exception)
            {
                return new BadRequest();
            }

            return new NoContent();
        }

        // POST: api/Categories
        public IHttpAction PostCategory(Category category)
        {
            db = new BlogContext();

            db.Categories.Add(category);
            db.SaveChanges();

            return new Created(category);
        }

        // DELETE: api/Categories/5
        public IHttpAction DeleteCategory(int id)
        {
            db = new BlogContext();
            Category category;
            if (CategoryExists(id))
            {
                category = db.Categories.Include(x => x.Posts).Single(x => x.Id == id);
            }
            else
            {
                return new NotFound();
            }

            category.Posts = null;

            db.Categories.Remove(category);
            db.SaveChanges();

            return new Ok(category);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }
    }
}
