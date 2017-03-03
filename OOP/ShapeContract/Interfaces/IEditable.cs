using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeContract
{
    public interface IEditable
    {
        bool Editing { get; set; }
    }
}
