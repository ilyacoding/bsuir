using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Command;
using Data;

namespace Serializer
{
    public class Serializer
    {
        public Response Deserialize(string str)
        {
            return JsonConvert.DeserializeObject<Response>(str, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public string Serialize(object response)
        {
            return JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });
        }
    }
}
