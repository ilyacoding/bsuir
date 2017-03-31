using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP
{
    [Serializable]
    public class ImageSettings
    {
        [XmlElement("Extension")]
        public string ImageExtension { get; set; }
        [XmlElement("Path")]
        public string ImagePath { get; set; }
    }
}
