using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CrudTcp.Models
{
    [XmlInclude(typeof(UserDto))]
    [XmlInclude(typeof(CategoryDto))]
    [XmlInclude(typeof(PostDto))]
    [XmlInclude(typeof(ReviewDto))]
    public interface IDto
    {
    }
}
