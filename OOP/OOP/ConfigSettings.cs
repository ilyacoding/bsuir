using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP
{
    [Serializable]
    public class WindowSettings
    {
        [XmlAttribute]
        public int Width { get; set; }
        [XmlAttribute]
        public int Height { get; set; }
    }

    [Serializable]
    public class ImageSettings
    {
        [XmlElement("Extension")]
        public string ImageExtension { get; set; }
        [XmlElement("Path")]
        public string ImagePath { get; set; }
    }

    [Serializable]
    public class InstrumentSettings
    {
        [XmlElement("Extension")]
        public string InstrumentExtension { get; set; }
        [XmlElement("Path")]
        public string InstrumentPath { get; set; }
    }

    [Serializable]
    public class ModuleSettings
    {
        [XmlElement("Path")]
        public string ModulePath { get; set; }
    }

    [Serializable]
    [XmlRoot("Settings")]
    public class ConfigSettings
    {
        //[XmlElement("WindowSize")]
        [XmlElement("Window")]
        public WindowSettings WindowSettings { get; set; }

        [XmlElement("Module")]
        public ModuleSettings ModuleSettings { get; set; }

        [XmlElement("Image")]
        public ImageSettings ImageSettings { get; set; }

        [XmlElement("Instrument")]
        public InstrumentSettings InstrumentSettings { get; set; }

        public ConfigSettings() { }
    }
}
