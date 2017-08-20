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
    public class ReviewsController : IController
    {
        private BlogContext db = new BlogContext();

        // GET: api/Reviews
        public IHttpAction GetReviews()
        {
            db = new BlogContext();
            return new Ok(db.Reviews.Select(x => new ReviewDto
            {
                Id = x.Id,
                Content = x.Content,
                Post = x.Post != null ? new PostDto()
                {
                    Id = x.Post.Id,
                    Content = x.Post.Content
                } : null,
                User = x.User != null ? new UserDto()
                {
                    Id = x.User.Id,
                    Name = x.User.Name
                } : null
            }).ToList());
        }

        // GET: api/Reviews/5
        public IHttpAction GetReview(int id)
        {
            db = new BlogContext();
            var review = db.Reviews.Select(x => new ReviewDto
            {
                Id = x.Id,
                Content = x.Content,
                Post = x.Post != null ? new PostDto()
                {
                    Id = x.Post.Id,
                    Content = x.Post.Content
                } : null,
                User = x.User != null ? new UserDto()
                {
                    Id = x.User.Id,
                    Name = x.User.Name
                } : null
            }).ToList().Find(x => x.Id == id);

            if (review == null)
            {
                return new NotFound();
            }

            return new Ok(review);
        }

        // PUT: api/Reviews/5
        public IHttpAction PutReview(int id, Review newReview)
        {
            db = new BlogContext();
            if (id != newReview.Id)
            {
                return new BadRequest();
            }

            try
            {
                var review = db.Reviews.Include(x => x.Post).Include(x => x.User).Single(x => x.Id == id);

                db.Entry(review).CurrentValues.SetValues(newReview);

                if (newReview.Post != null)
                {
                    if (review.Post != null)
                    {
                        if (review.Post.Id != newReview.Post.Id)
                        {
                            db.Posts.Attach(newReview.Post);
                            review.Post = newReview.Post;
                        }
                    }
                    else
                    {
                        db.Posts.Attach(newReview.Post);
                        review.Post = newReview.Post;
                    }
                }
                else
                {
                    review.Post = null;
                }

                if (newReview.User != null)
                {
                    if (review.User != null)
                    {
                        if (review.User.Id != newReview.User.Id)
                        {
                            db.Users.Attach(newReview.User);
                            review.User = newReview.User;
                        }
                    }
                    else
                    {
                        db.Users.Attach(newReview.User);
                        review.User = newReview.User;
                    }
                }
                else
                {
                    review.User = null;
                }

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Reviews
        public IHttpAction PostReview(Review review)
        {
            db = new BlogContext();

            db.Reviews.Add(review);
            db.SaveChanges();

            return new Created(review);
        }

        // DELETE: api/Reviews/5
        public IHttpAction DeleteReview(int id)
        {
            db = new BlogContext();

            Review review;
            if (ReviewExists(id))
            {
                review = db.Reviews.Include(x => x.User).Include(x => x.Post).Single(x => x.Id == id);
            }
            else
            {
                return new NotFound();
            }

            review.User = null;
            review.Post = null;

            db.Reviews.Remove(review);
            db.SaveChanges();

            return new Ok(review);
        }
        
        private bool ReviewExists(int id)
        {
            return db.Reviews.Count(e => e.Id == id) > 0;
        }
    }
}
