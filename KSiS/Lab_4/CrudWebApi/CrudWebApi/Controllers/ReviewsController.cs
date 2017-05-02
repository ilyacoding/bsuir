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
using CrudWebApi.Models;

namespace CrudWebApi.Controllers
{
    public class ReviewsController : ApiController
    {
        private BlogContext db = new BlogContext();

        // GET: api/Reviews
        public IList<ReviewDto> GetReviews()
        {
            return db.Reviews.Select(x => new ReviewDto
            {
                Id = x.Id,
                Content = x.Content,
                Post = x.Post,
                User = x.User
            }).ToList();
        }

        // GET: api/Reviews/5
        [ResponseType(typeof(Review))]
        public IHttpActionResult GetReview(int id)
        {
            var review = db.Reviews.Select(x => new ReviewDto
            {
                Id = x.Id,
                Content = x.Content,
                Post = x.Post,
                User = x.User
            }).ToList().Find(x => x.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // PUT: api/Reviews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReview(int id, Review newReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newReview.Id)
            {
                return BadRequest();
            }
            
            try
            {
                var review = db.Reviews.Include(x => x.Post).Include(x => x.User).Single(x => x.Id == id);

                db.Entry(review).CurrentValues.SetValues(newReview);

                review.Post = newReview.Post;
                review.User = newReview.User;

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Reviews
        [ResponseType(typeof(Review))]
        public IHttpActionResult PostReview(Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reviews.Add(review);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = review.Id }, review);
        }

        // DELETE: api/Reviews/5
        [ResponseType(typeof(Review))]
        public IHttpActionResult DeleteReview(int id)
        {
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }

            db.Reviews.Remove(review);
            db.SaveChanges();

            return Ok(review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewExists(int id)
        {
            return db.Reviews.Count(e => e.Id == id) > 0;
        }
    }
}