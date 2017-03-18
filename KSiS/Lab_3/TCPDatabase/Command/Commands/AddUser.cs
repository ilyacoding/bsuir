
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class AddUser : ICommand
    {
        public object[] array { get; set; }
    }
}
