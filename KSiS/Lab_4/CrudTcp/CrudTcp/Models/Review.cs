using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTcp.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public Post Post { get; set; }

        public User User { get; set; }
    }
}
