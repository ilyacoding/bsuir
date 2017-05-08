using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTcp.Models
{
    [Serializable]
    public class CategoryDto : IDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Post> Posts { get; set; }
    }
}
