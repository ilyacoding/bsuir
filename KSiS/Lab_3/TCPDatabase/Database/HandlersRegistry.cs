using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class HandlersRegistry
    {
        private Dictionary<Type, ICommandHandler> dict = new Dictionary<Type, ICommandHandler>();
        private ICommandHandler Default { get; set; }

        public void RegDefault(ICommandHandler handler)
        {
            Default = handler;
        }

        public void Reg(Type commandType, ICommandHandler handler)
        {
            dict.Add(commandType, handler);
        }

        public ICommandHandler Get(Type comType)
        {
            return dict[comType];
        }
    }
}
