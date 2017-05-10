using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CrudTcp.Serialization
{
    public class JsonSerializer : ISerializer
    {
        public string Mime { get; set; }

        public JsonSerializer()
        {
            Mime = "application/json";
        }

        public string Serialize(object obj, Type type)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public object Deserialize(string str, Type type)
        {
            return JsonConvert.DeserializeObject(str, type, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
