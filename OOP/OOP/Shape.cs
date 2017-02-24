using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP
{
    /*public abstract class Shape
    {
        public System.Drawing.Rectangle Coordinate { get; set; }
        public abstract void Draw(System.Drawing.Graphics graphics);
        public System.Drawing.Pen Pen { get; set; }
    }*/

    public abstract class Shape
    {
        protected System.Drawing.Rectangle Coordinate { get; set; }
        protected Color PenColor { get; set; }
        protected float PenWidth { get; set; }

        public abstract void Draw(Graphics graphics);
    }

    /*public class Trapeze1 : Shape
    {
        public Trapeze1(Color color, float width, int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2 - x1, y2 - y1);
            PenColor = color;
            PenWidth = width;
            //Pen = new Pen(PenColor, PenWidth);
        }
        public override void Draw(Graphics graphics)
        {
            //System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawLine(new Pen(PenColor, PenWidth), new Point(Coordinate.X, Coordinate.Bottom), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom));
            graphics.DrawLine(new Pen(PenColor, PenWidth), new Point(Coordinate.X + Coordinate.Width / 4, Coordinate.Y), new Point(Coordinate.X - Coordinate.Width / 4 + Coordinate.Width, Coordinate.Y));
            graphics.DrawLine(new Pen(PenColor, PenWidth), new Point(Coordinate.X + Coordinate.Width / 4, Coordinate.Y), new Point(Coordinate.X, Coordinate.Bottom));
            graphics.DrawLine(new Pen(PenColor, PenWidth), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom), new Point(Coordinate.X - Coordinate.Width / 4 + Coordinate.Width, Coordinate.Y));
        }
    }*/
}