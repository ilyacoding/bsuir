using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command;

namespace Database
{
    public class AddReferenceCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public AddReferenceCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(ICommand command)
        {
            var addReference = (AddReference)command;

            return db.AddReference(addReference.GoodId, addReference.CategoryId);
        }
    }
}
