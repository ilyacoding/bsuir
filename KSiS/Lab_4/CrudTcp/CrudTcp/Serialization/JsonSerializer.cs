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

        public string Serialize<T>(T obj) where T : class
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                //TypeNameHandling = TypeNameHandling.All
            });
        }

        public T Deserialize<T>(string str) where T : class
        {
            return JsonConvert.DeserializeObject<T>(str, new JsonSerializerSettings
            {
                //TypeNameHandling = TypeNameHandling.All
            });
        }
    }
}
