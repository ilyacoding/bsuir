using System;
using System.Collections.Generic;

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
            ICommandHandler cmdHandler;
            try
            {
                cmdHandler = dict[comType];
            }
            catch (Exception)
            {
                cmdHandler = Default;
            }
            return cmdHandler;
        }
    }
}
