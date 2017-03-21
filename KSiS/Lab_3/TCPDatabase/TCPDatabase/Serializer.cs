using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Command;

namespace TCPDatabase
{
    public static class Serializer
    {
        public static ICommand Deserialize(string str)
        {
            return JsonConvert.DeserializeObject<ICommand>(str, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public static string Serialize(IResponse response)
        {
            return JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });
        }
    }
}
