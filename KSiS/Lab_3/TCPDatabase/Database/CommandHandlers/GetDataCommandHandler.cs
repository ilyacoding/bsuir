using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class GetDataCommandHandler : ICommandHandler
    {
        private Database db { get; }
        public GetDataCommandHandler(Database db)
        {
            this.db = db;
        }

        public object Execute(Command.ICommand command)
        {
            return db.GetData();
        }
    }
}
