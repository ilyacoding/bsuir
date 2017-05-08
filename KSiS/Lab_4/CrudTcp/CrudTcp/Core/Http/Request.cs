using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CrudTcp.Serialization;

namespace CrudTcp.Core.Http
{
    public class Request
    {
        private ISerializer Serializer { get; set; }
        public SerializerRegistry SerializerRegistry { get; set; }

        public string Method { get; set; }
        public object[] Parameters { get; set; }
        public Uri Uri { get; set; }
        private Dictionary<string, string> Fields { get; set; }
        public string Body { get; set; }

        public Request(SerializerRegistry serializerRegistry)
        {
            SerializerRegistry = serializerRegistry;
        }

        public string GetField(string key)
        {
            try
            {
                return Fields[key];
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void Parse(string data)
        {
            var parts = data.Split(new [] {"\r\n\r\n"}, StringSplitOptions.None);
            if (parts.Length < 1) throw new Exception("Invalid data");

            Body = parts.Length == 2 ? parts[1] : "";

            var headers = parts[0].Split('\n').ToList();

            var startingLine = headers[0].Split(' ');
            headers.RemoveAt(0);

            if (startingLine.Length != 3) throw new Exception();
            Method = startingLine[0];
            Uri = Uri.Parse(startingLine[1]);

            Fields = headers.Select(p => p.Split(new[] { ':' }, 2)).Where(f => f.Count() > 1).ToDictionary(f => f[0].Trim(), f => f[1].Trim());

            Serializer = SerializerRegistry.Get(GetField("Content-type"));

            ParseParameters();
        }

        //public object ParseBody()
        //{
        //    if (Body.Length > 0)
        //    {
        //        throw new NotImplementedException();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        
        public void ParseParameters()
        {
            var parameters = new List<object>();

            foreach (var parameter in Uri.UrlParams)
            {
                try
                {
                    var par = Convert.ToInt32(parameter);
                    parameters.Add(par);
                }
                catch (Exception)
                {
                    parameters.Add(parameter);
                }
            }

            if (Body.Length > 0)
            {
                parameters.Add(Serializer.Deserialize<object>(Body));
            }

            Parameters = parameters.Count > 0 ? parameters.ToArray() : null;
        }

        //public void ParseBody()
        //{
        //    if (Body.Length > 0)
        //    {
        //        Parameters[Parameters.Length - 1] = Serializer.Deserialize<object>((string)Parameters.Last());
        //    }
        //}
    }
}
