using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWebApi.Models
{
    public class UserDto : IDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Review> Reviews { get; set; }
    }
}