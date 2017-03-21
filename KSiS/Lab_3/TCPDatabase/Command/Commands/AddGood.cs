
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class AddGood : ICommand
    {
        // public object[] array { get; set; }
        string Good { get; set; }
    }

    public interface ICommandHandler
    {
        IResponse Execute(ICommand command);
    }

    public class AddCGoodCommandHandler : ICommandHandler
    {

        public AddCGoodCommandHandler(Database db )
        {
            this.db = db;
        }

        public object Execute(ICommand command)
        {
            var addGood = (AddGood)command;

            db.Method

            return null;
        }
    }

    public class HandlersREgistry
    {
        private Dictionary<Type, ICommandHandler> dict = new Dictionary<Type, ICommandHandler>();

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
