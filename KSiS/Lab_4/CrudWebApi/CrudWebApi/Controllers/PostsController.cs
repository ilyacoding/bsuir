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
    public class PostsController : ApiController
    {
        private BlogContext db = new BlogContext();

        // GET: api/Posts
        public IList<PostDto> GetPosts()
        {
            return db.Posts.Select(x => new PostDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Categories = x.Categories.ToList(),
                Reviews = x.Reviews.ToList()
            }).ToList();
        }

        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
            var post = db.Posts.Select(x => new PostDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Categories = x.Categories.ToList(),
                Reviews = x.Reviews.ToList()
            }).ToList().Find(x => x.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(int id, Post newPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newPost.Id)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Posts
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(int id)
        {
            Post post;
            if (PostExists(id))
            {
                post = db.Posts.Include(x => x.Categories).Include(x => x.Reviews).Single(x => x.Id == id);
            }
            else
            {
                return NotFound();
            }

            post.Categories = null;
            post.Reviews = null;

            db.Posts.Remove(post);
            db.SaveChanges();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}