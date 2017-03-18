using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandAttribute
{
    public class CommandAttribute : Attribute
    {
        public string MethodName { get; private set; }
        public string  { get; set; }

        public HelpAttribute(string url)
        {
            Url = url;
        }
    }
}
