using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CrudTcp.Models
{
    [Serializable]
    public class CategoryDto : IDto
    {
        [XmlElement]
        public int Id { get; set; }

        [XmlElement]
        public string Title { get; set; }

        [XmlArray]
        public List<PostDto> Posts { get; set; }
    }
}
