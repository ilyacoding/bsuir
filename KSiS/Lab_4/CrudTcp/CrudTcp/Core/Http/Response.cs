using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTcp.Core.Http
{
    public class Response
    {
        public string Status { get; set; }
        public byte[] Data { get; set; }

        public Dictionary<string, string> Fields { get; set; }

        public Response(string status, byte[] data)
        {
            Status = status;
            Data = data;

            Fields = new Dictionary<string, string>();
        }
    }
}
