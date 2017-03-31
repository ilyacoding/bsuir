using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP
{
    [Serializable]
    [XmlRoot("Settings")]
    public class ConfigSettings
    {
        [XmlElement("Window")]
        public WindowSettings WindowSettings { get; set; }

        [XmlElement("Module")]
        public ModuleSettings ModuleSettings { get; set; }

        [XmlElement("Image")]
        public ImageSettings ImageSettings { get; set; }

        [XmlElement("Instrument")]
        public InstrumentSettings InstrumentSettings { get; set; }

        public ConfigSettings() { }

        public bool IsValid()
        {
            if (WindowSettings.Width < 1) return false;
            if (WindowSettings.Height < 1) return false;
            if (!Directory.Exists(ModuleSettings.ModulePath)) return false;
            if (!Directory.Exists(ImageSettings.ImagePath)) return false;
            if (!Directory.Exists(InstrumentSettings.InstrumentPath)) return false;

            if (!IsValidExtension(ImageSettings.ImageExtension)) return false;
            if (!IsValidExtension(InstrumentSettings.InstrumentExtension)) return false;

            return true;
        }

        public bool IsValidExtension(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }
    }
}
