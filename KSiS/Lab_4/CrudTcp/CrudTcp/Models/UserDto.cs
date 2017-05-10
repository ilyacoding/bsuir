using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CrudTcp.Models
{
    [Serializable]
    public class UserDto : IDto
    {
        [XmlElement]
        public int Id { get; set; }
        
        [XmlElement]
        public string Name { get; set; }
        
        [XmlArray]
        public List<ReviewDto> Reviews { get; set; }

        //public void ToDto()
        //{
        //    foreach (var review in Reviews)
        //    {
        //        review.User = null;
        //        review.Post = null;
        //    }
        //}
    }
}
