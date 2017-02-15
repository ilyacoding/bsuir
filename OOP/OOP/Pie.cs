using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Pie : Shape
    {
        public Pie(int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2, y2);
        }
        public override void Draw(FormMain form)
        {
            float startAngle = 0.0F;
            float sweepAngle = 90.0F;
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawPie(System.Drawing.Pens.Red, Coordinate, startAngle, sweepAngle);
        }
    }
}
