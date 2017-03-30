using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class SelectByGoodId : ICommand
    {
        public int GoodId { get; set; }
        public bool Dependency { get; set; }
    }
}
