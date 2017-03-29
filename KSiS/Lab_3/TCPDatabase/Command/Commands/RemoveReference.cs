using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class RemoveReference : ICommand
    {
        public int GoodId { get; set; }
        public int CategoryId { get; set; }
    }
}
