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
        public Ellipse(System.Drawing.Color color, float width, int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2 - x1, y2 - y1);
            Pen = new Pen(color, width);
        }
        public override void Draw(FormMain form)
        {
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawEllipse(Pen, Coordinate);
        }
    }
}
