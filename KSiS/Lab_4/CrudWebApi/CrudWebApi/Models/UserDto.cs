using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWebApi.Models
{
    public class UserDto
    {
//        public UserDto(User user)
//        {
//            Id = user.Id;
//            Name = user.Name;
//            Reviews = user.Reviews.ToList();
//        }

        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Review> Reviews { get; set; }
    }
}