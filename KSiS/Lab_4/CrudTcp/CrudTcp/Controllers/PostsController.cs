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
    public class PostsController : IController
    {
        private BlogContext db = new BlogContext();

        // GET: api/Posts
        public IHttpAction GetPosts()
        {
            return new Ok(db.Posts.Select(x => new PostDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Categories = x.Categories.Select(y => new CategoryDto()
                {
                    Id = y.Id,
                    Title = y.Title
                }).ToList(),
                Reviews = x.Reviews.Select(y => new ReviewDto()
                {
                    Id = y.Id,
                    Content = y.Content
                }).ToList()
            }).ToList());
        }

        // GET: api/Posts/5
        public IHttpAction GetPost(int id)
        {
            db = new BlogContext();
            var post = db.Posts.Select(x => new PostDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Categories = x.Categories.Select(y => new CategoryDto()
                {
                    Id = y.Id,
                    Title = y.Title
                }).ToList(),
                Reviews = x.Reviews.Select(y => new ReviewDto()
                {
                    Id = y.Id,
                    Content = y.Content
                }).ToList()
            }).ToList().Find(x => x.Id == id);

            if (post == null)
            {
                return new NotFound();
            }

            return new Ok(post);
        }

        // PUT: api/Posts/5
        public IHttpAction PutPost(int id, Post newPost)
        {
            db = new BlogContext();
            if (id != newPost.Id)
            {
                return new BadRequest();
            }

            try
            {
                var post = db.Posts.Include(x => x.Reviews).Include(x => x.Categories).Single(x => x.Id == id);

                db.Entry(post).CurrentValues.SetValues(newPost);

                foreach (var review in post.Reviews.ToList())
                {
                    // ReSharper disable once SimplifyLinqExpression
                    if (!newPost.Reviews.Any(x => x.Id == review.Id))
                    {
                        post.Reviews.Remove(review);
                    }
                }

                foreach (var category in post.Categories.ToList())
                {
                    // ReSharper disable once SimplifyLinqExpression
                    if (!newPost.Categories.Any(x => x.Id == category.Id))
                    {
                        post.Categories.Remove(category);
                    }
                }

                foreach (var review in newPost.Reviews)
                {
                    if (post.Reviews.Any(x => x.Id == review.Id)) continue;
                    db.Reviews.Attach(review);
                    post.Reviews.Add(review);
                }

                foreach (var category in newPost.Categories)
                {
                    if (post.Categories.Any(x => x.Id == category.Id)) continue;
                    db.Categories.Attach(category);
                    post.Categories.Add(category);
                }

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        public IHttpAction PostPost(Post post)
        {
            db = new BlogContext();
            db.Posts.Add(post);
            db.SaveChanges();

            return new Created(post);
        }

        // DELETE: api/Posts/5
        public IHttpAction DeletePost(int id)
        {
            db = new BlogContext();
            Post post;
            if (PostExists(id))
            {
                post = db.Posts.Include(x => x.Categories).Include(x => x.Reviews).Single(x => x.Id == id);
            }
            else
            {
                return new NotFound();
            }

            post.Categories = null;
            post.Reviews = null;

            db.Posts.Remove(post);
            db.SaveChanges();

            return new Ok(post);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}
