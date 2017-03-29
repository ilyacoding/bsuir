using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class RemoveCategoryCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public RemoveCategoryCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            var removeCategory = (Command.RemoveCategory)command;

            return db.RemoveCategory(removeCategory.CatId);
        }
    }
}
