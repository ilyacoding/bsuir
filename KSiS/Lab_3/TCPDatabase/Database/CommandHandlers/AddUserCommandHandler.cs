using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AddUserCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public AddUserCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            var addUser = (Command.AddUser)command;

            return db.AddGood(addUser.User);
        }
    }
}
