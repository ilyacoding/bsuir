using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP
{
    public class ConfigSerializer
    {
        public void Serialize(ConfigSettings configSettings, string filePath)
        { 
            var formatter = new XmlSerializer(typeof(ConfigSettings));
            File.Delete(filePath);
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, configSettings);
            }
        }

        public ConfigSettings Deserialize(string filePath)
        {
            var formatter = new XmlSerializer(typeof(ConfigSettings));
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return (ConfigSettings)formatter.Deserialize(fs);
            }
        }
    }
}
