using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Database
    {
        public DatabaseModelContainer Container { get; set; }
        public Database(DatabaseModelContainer container)
        {
            Container = container;
        }

        public void Save()
        {
            Container.SaveChanges();
        }

        public void AddUser()
        {
            
        }
    }
}
