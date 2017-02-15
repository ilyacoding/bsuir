using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP
{
    public class Line : Shape
    {
        public Line(System.Drawing.Color color, int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2, y2);
            Pen = new Pen(color);
            //Pen.color = color;
        }
        public override void Draw(FormMain form)
        {
            //Coordinate.X
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawLine(Pen, new Point(Coordinate.X, Coordinate.Y), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom));
        }
    }
}
