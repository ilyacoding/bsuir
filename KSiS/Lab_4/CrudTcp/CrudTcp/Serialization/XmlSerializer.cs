using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using CrudTcp.Models;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

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

        public string Serialize(object obj, Type type)
        {
            var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return JsonConvert.DeserializeXmlNode("{\"Row\":" + json + "}", type.Name, true).InnerXml;

            //var xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
            //
            //var textWriter = new StringWriter();
            //
            //xmlSerializer.Serialize(textWriter, obj);
            //
            //return textWriter.ToString();
        }

        //public T Deserialize<T>(string str) where T : class
        //{
        //    var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        //
        //    var textReader = new StringReader(str);
        //
        //    return (T) xmlSerializer.Deserialize(textReader);
        //}

        public object Deserialize(string str, Type type)
        {
            //var xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
            //
            //var textReader = new StringReader(str);
            //
            //return xmlSerializer.Deserialize(textReader);

            // To convert an XML node contained in string xml into a JSON string   
            string json = "";
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(str);
                json = JsonConvert.SerializeXmlNode(xmlDoc, Formatting.None, true);

                return JsonConvert.DeserializeObject(json, type, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            catch (Exception e)
            {

                Console.WriteLine("SPECIAL===============================");
                Console.WriteLine(json);
                throw;
            }
        }
    }
}
