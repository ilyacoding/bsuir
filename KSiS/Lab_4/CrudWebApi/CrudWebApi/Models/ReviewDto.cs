using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWebApi.Models
{
    public class ReviewDto
    {
        public int Id { get; set; }
        
        public string Content { get; set; }

        public Post Post { get; set; }

        public User User { get; set; }
    }
}