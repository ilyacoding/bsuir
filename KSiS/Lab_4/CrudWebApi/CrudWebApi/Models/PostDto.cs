using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWebApi.Models
{
    public class PostDto : IDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }

        public List<Category> Categories { get; set; }

        public List<Review> Reviews { get; set; }
    }
}