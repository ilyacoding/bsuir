using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command;
using Data;
using Newtonsoft.Json;

namespace Database
{
    public class DbSerializer
    {
        public Data.Data Deserialize(string str)
        {
            return JsonConvert.DeserializeObject<Data.Data>(str, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public string Serialize(Data.Data Data)
        {
            return JsonConvert.SerializeObject(Data, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });
        }
    }
}
