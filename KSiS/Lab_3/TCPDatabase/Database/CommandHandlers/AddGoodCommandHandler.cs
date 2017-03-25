using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AddGoodCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public AddGoodCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            var addGood = (Command.AddGood)command;

            return db.AddGood(addGood.Good);
        }
    }
}
