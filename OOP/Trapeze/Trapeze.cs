using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.Composition;
using ShapeContract;

namespace Trapeze
{
    [Export(typeof(Shape))]
    public class Trapeze : Shape
    {
        public Trapeze(System.Drawing.Color color, float width, int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2 - x1, y2 - y1);
            PenColor = color;
            PenWidth = width;
        }

        public Trapeze()
        {
            Coordinate = new System.Drawing.Rectangle(0, 0, 0, 0);
            PenColor = Color.Black;
            PenWidth = 1;
        }

        public override void Draw(System.Drawing.Graphics graphics)
        {
            //System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            var pen = new Pen(PenColor, PenWidth);
            graphics.DrawLine(pen, new Point(Coordinate.X, Coordinate.Bottom), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom));
            graphics.DrawLine(pen, new Point(Coordinate.X + Coordinate.Width / 4, Coordinate.Y), new Point(Coordinate.X - Coordinate.Width / 4 + Coordinate.Width, Coordinate.Y));
            graphics.DrawLine(pen, new Point(Coordinate.X + Coordinate.Width / 4, Coordinate.Y), new Point(Coordinate.X, Coordinate.Bottom));
            graphics.DrawLine(pen, new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom), new Point(Coordinate.X - Coordinate.Width / 4 + Coordinate.Width, Coordinate.Y));
        }
    }
}
