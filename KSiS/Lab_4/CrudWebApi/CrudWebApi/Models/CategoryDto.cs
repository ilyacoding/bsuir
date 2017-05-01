using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWebApi.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public List<Post> Posts { get; set; }
    }
}