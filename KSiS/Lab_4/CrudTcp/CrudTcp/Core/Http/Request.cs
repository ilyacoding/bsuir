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
        private Dictionary<string, string> Fields { get; set; }
        
        public string Method { get; set; }
        public object[] Parameters { get; set; }
        public Uri Uri { get; set; }
        public string Body { get; set; }
        
        public Request(string data)
        {
            var parts = data.Split(new[] { "\r\n\r\n" }, StringSplitOptions.None);
            if (parts.Length < 1) throw new Exception("Invalid data");

            Body = parts.Length == 2 ? parts[1] : "";

            var headers = parts[0].Split('\n').ToList();

            var startingLine = headers[0].Split(' ');
            headers.RemoveAt(0);

            if (startingLine.Length != 3) throw new Exception();
            Method = startingLine[0];
            Uri = Uri.Parse(startingLine[1]);

            Fields = headers.Select(p => p.Split(new[] { ':' }, 2)).Where(f => f.Count() > 1).ToDictionary(f => f[0].Trim(), f => f[1].Trim());            
        }

        public string GetField(string key)
        {
            return Fields.ContainsKey(key) ? Fields[key] : "";
        }
    }
}
