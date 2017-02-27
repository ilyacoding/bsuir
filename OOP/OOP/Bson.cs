using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Drawing;

namespace OOP
{
    public static class Bson
    {
        public static byte[] Serialize(Object obj)
        {
            MemoryStream ms = new MemoryStream();
            using (BsonWriter writer = new BsonWriter(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, obj);
            }
            return ms.ToArray();
        }

        public static List<Shape> DeSerialize(byte[] data)
        {
            List<Shape> obj;
            MemoryStream ms = new MemoryStream(data);
            using (BsonReader reader = new BsonReader(ms))
            {
                reader.ReadRootValueAsArray = true;

                JsonSerializer serializer = new JsonSerializer();
                obj = serializer.Deserialize<List<Shape>>(reader);
            }
            return obj;
        }
    }
}
