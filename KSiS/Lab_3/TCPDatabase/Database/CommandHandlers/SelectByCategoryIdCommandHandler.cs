using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class SelectByCategoryIdCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public SelectByCategoryIdCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            var select = (Command.SelectByCategoryId)command;
            return db.SelectByCategoryId(select.CategoryId, select.Dependency);
        }
    }
}