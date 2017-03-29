using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class RemoveUserCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public RemoveUserCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            var removeUser = (Command.RemoveUser)command;

            return db.RemoveUser(removeUser.UserId);
        }
    }
}
