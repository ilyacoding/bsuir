using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTcp.Core.Http.Action
{
    public class MethodNotAllowed : IHttpAction
    {
        public int Code { get; set; }
        public object Object { get; set; }

        public MethodNotAllowed()
        {
            Code = 405;
            Object = null;
        }
    }
}
