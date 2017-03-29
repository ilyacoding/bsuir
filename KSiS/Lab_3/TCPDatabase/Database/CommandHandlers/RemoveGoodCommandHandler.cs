using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class RemoveGoodCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public RemoveGoodCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            var removeGood = (Command.RemoveGood)command;

            return db.RemoveGood(removeGood.GoodId);
        }
    }
}
