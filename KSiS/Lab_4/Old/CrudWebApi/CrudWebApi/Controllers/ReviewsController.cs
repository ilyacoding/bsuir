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
using CrudWebApi;

namespace CrudWebApi.Controllers
{
    public class ReviewsController : ApiController
    {
        private BlogRepository db = new BlogRepository(new BlogContextEntities(), new[] { "Users" });

        // GET: api/Reviews
        public IQueryable<Review> GetReviewSet()
        {
            return db.ReadAll<Review>();
        }

        // GET: api/Reviews/5
        [ResponseType(typeof(Review))]
        public IHttpActionResult GetReview(int id)
        {
            var review = db.Read<Review>(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // PUT: api/Reviews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReview(int id, Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != review.Id)
            {
                return BadRequest();
            }

            if (db.Update(review))
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else if (!ReviewExists(id))
            {
                return NotFound();
            }
            else
            {
                throw new Exception();
            }
        }

        // POST: api/Reviews
        [ResponseType(typeof(Review))]
        public IHttpActionResult PostReview(Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(review);

            return CreatedAtRoute("DefaultApi", new { id = review.Id }, review);
        }

        // DELETE: api/Reviews/5
        [ResponseType(typeof(Review))]
        public IHttpActionResult DeleteReview(int id)
        {
            var review = db.Read<Review>(id);
            if (review == null)
            {
                return NotFound();
            }

            db.Delete(review);

            return Ok(review);
        }

        private bool ReviewExists(int id)
        {
            return db.ReadAll<Review>().Count(e => e.Id == id) > 0;
        }
    }
}