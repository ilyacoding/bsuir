using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP
{
    public class Ellipse : Shape
    {
        public Ellipse(Color color, float width, int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2 - x1, y2 - y1);
            PenColor = color;
            PenWidth = width;
        }

        public override void Draw(Graphics graphics)
        {
            var pen = new Pen(PenColor, PenWidth);
            graphics.DrawEllipse(pen, Coordinate);
        }
    }
}
