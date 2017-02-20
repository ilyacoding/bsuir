using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP
{
    public abstract class Shape
    {
        public System.Drawing.Rectangle Coordinate { get; set; }
        public System.Drawing.Pen Pen { get; set; }
        public virtual void Draw(FormMain form) { }
    }
}
