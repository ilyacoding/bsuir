using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudTcp.Serialization;

namespace CrudTcp.Core
{
    public class SerializerRegistry
    {
        private Dictionary<List<string>, ISerializer> Dictionary { get; set; }
        private ISerializer Default { get; set; }

        public SerializerRegistry()
        {
            Dictionary = new Dictionary<List<string>, ISerializer>();
        }

        public void Reg(List<string> entryList, ISerializer serializer)
        {
            Dictionary.Add(entryList, serializer);
        }

        public void RegDefault(ISerializer serializer)
        {
            Default = serializer;
        }

        public ISerializer Get(string str)
        {
            foreach (var entry in Dictionary)
            {
                if (entry.Key.Any(key => key == str))
                {
                    return entry.Value;
                }
            }

            return Default;
        }
    }
}
