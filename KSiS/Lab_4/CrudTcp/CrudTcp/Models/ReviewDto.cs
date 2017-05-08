using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTcp.Models
{
    [Serializable]
    public class ReviewDto : IDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public Post Post { get; set; }

        public User User { get; set; }
    }
}
