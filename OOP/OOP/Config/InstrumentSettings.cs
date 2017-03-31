using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP
{
    [Serializable]
    public class InstrumentSettings
    {
        [XmlElement("Extension")]
        public string InstrumentExtension { get; set; }
        [XmlElement("Path")]
        public string InstrumentPath { get; set; }
    }
}
