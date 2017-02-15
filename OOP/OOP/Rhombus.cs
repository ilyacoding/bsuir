using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP
{
    public class Rhombus : Shape
    {
        public Rhombus(int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2, y2);
        }
        public override void Draw(FormMain form)
        {
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawLine(System.Drawing.Pens.Red, new Point((Coordinate.X + Coordinate.Width) / 2, Coordinate.Y), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom / 2));
            graphics.DrawLine(System.Drawing.Pens.Red, new Point((Coordinate.X + Coordinate.Width) / 2, Coordinate.Y), new Point(Coordinate.X, Coordinate.Bottom / 2));
            graphics.DrawLine(System.Drawing.Pens.Red, new Point(Coordinate.X, Coordinate.Bottom / 2), new Point((Coordinate.X + Coordinate.Width) / 2, Coordinate.Bottom));
            graphics.DrawLine(System.Drawing.Pens.Red, new Point((Coordinate.X + Coordinate.Width) / 2, Coordinate.Bottom), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom / 2));
        }
    }
}
