using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class SelectByGoodIdCommandHandler : ICommandHandler
    {
        private Database db { get; set; }
        public SelectByGoodIdCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            var select = (Command.SelectByGoodId)command;
            return db.SelectByGoodId(select.GoodId, select.Dependency);
        }
    }
}
