using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Shape
    {
        public System.Drawing.Rectangle Coordinate { get; set; }
        public System.Drawing.Pen Pen { get; set; }
        public virtual void Draw(FormMain form) { }
    }
}
