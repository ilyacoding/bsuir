using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP
{
    [Serializable]
    public class ModuleSettings
    {
        [XmlElement("Path")]
        public string ModulePath { get; set; }
    }
}
