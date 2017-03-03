using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapeContract
{
    public abstract class Shape
    {
        public Rectangle Coordinate { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }

        public abstract void Draw(Graphics graphics);
    }
}
