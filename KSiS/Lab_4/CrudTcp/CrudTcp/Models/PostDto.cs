using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CrudTcp.Models
{
    [Serializable]
    public class PostDto : IDto
    {
        [XmlElement]
        public int Id { get; set; }

        [XmlElement]
        public string Title { get; set; }

        [XmlElement]
        public string Content { get; set; }

        [XmlArray]
        public List<CategoryDto> Categories { get; set; }

        [XmlArray]
        public List<ReviewDto> Reviews { get; set; }
    }
}
