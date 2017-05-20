using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudTcp.Controllers;

namespace CrudTcp.Core
{
    public class ControllersRegistry
    {
        private Dictionary<string, IController> Dictionary { get; set; }

        public ControllersRegistry()
        {
            Dictionary = new Dictionary<string, IController>();
        }

        public void Reg(string str, IController controller)
        {
            Dictionary.Add(str, controller);
        }

        public IController Get(string str)
        {
            str = str.Trim();
            if (!Dictionary.ContainsKey(str)) throw new Exception();
            return Dictionary[str];
        }
    }
}
