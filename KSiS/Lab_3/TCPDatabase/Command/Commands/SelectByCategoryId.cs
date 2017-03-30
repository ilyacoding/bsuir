using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class SelectByCategoryId : ICommand
    {
        public int CategoryId { get; set; }
        public bool Dependency { get; set; }
    }
}
