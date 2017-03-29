using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DefaultCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public DefaultCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            return null;
        }
    }
}
