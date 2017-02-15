using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP
{
    public class Pie : Shape
    {
        public Pie(System.Drawing.Color color, int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2 - x1, y2 - y1);
            Pen = new Pen(color);
        }
        public override void Draw(FormMain form)
        {
            float startAngle = 0.0F;
            float sweepAngle = 90.0F;
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawPie(Pen, Coordinate, startAngle, sweepAngle);
        }
    }
}
