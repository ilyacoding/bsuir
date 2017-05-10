using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CrudTcp.Models
{
    [Serializable]
    public class ReviewDto : IDto
    {
        [XmlElement]
        public int Id { get; set; }

        [XmlElement]
        public string Content { get; set; }

        [XmlElement]
        public PostDto Post { get; set; }

        [XmlElement]
        public UserDto User { get; set; }
    }
}
