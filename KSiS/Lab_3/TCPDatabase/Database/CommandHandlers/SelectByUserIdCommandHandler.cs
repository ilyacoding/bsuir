using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class SelectByUserIdCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public SelectByUserIdCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            var select = (Command.SelectByUserId)command;
            return db.SelectByUserId(select.UserId, select.Dependency);
        }
    }
}
