using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CrudTcp.Serialization
{
    public class XmlSerializer : ISerializer
    {
        public string Mime { get; set; }

        public XmlSerializer()
        {
            Mime = "application/xml";
        }

        public string Serialize<T>(T obj) where T : class 
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            var textWriter = new StringWriter();
            
            xmlSerializer.Serialize(textWriter, obj);

            return textWriter.ToString();
        }

        public T Deserialize<T>(string str) where T : class
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            var textReader = new StringReader(str);

            return (T) xmlSerializer.Deserialize(textReader);
        }
    }
}
