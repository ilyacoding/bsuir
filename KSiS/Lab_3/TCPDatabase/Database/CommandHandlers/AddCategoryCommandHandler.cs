using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AddCategoryCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public AddCategoryCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            var addCategory = (Command.AddCategory)command;

            return db.AddCategory(addCategory.Category);
        }
    }
}
