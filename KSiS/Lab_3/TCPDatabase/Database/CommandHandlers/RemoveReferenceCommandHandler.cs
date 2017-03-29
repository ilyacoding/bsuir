using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command;
using Data;

namespace Database
{
    public class RemoveReferenceCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public RemoveReferenceCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            var removeReference = (RemoveReference)command;

            return db.RemoveReference(removeReference.GoodId, removeReference.CategoryId);
        }
    }
}
