using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CrudTcp.Serialization
{
    public interface ISerializer
    {
        string Mime { get; set; }
        string Serialize<T>(T obj) where T : class ;
        T Deserialize<T>(string str) where T : class;
    }
}
