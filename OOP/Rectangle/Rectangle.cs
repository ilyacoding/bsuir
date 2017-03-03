using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.Composition;
using ShapeContract;

namespace Rectangle
{
    [Export(typeof(Shape))]
    public partial class Rectangle : Shape, ISelectable
    {
        public bool Selected { get; set; }
        public Rectangle(Color color, float width, int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2 - x1, y2 - y1);
            PenColor = color;
            PenWidth = width;
        }

        public Rectangle()
        {
            Coordinate = new System.Drawing.Rectangle(0, 0, 0, 0);
            PenColor = Color.Black;
            PenWidth = 1;
        }

        public override void Draw(Graphics graphics)
        {
            var pen = new Pen(PenColor, PenWidth);
            graphics.DrawLine(pen, new Point(Coordinate.X, Coordinate.Y), new Point(Coordinate.X + Coordinate.Width, Coordinate.Y));
            graphics.DrawLine(pen, new Point(Coordinate.X, Coordinate.Y), new Point(Coordinate.X, Coordinate.Bottom));
            graphics.DrawLine(pen, new Point(Coordinate.X + Coordinate.Width, Coordinate.Y), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom));
            graphics.DrawLine(pen, new Point(Coordinate.X, Coordinate.Bottom), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom));

            if (Selected)
            {
                var penBack = new Pen(Brushes.Red, PenWidth);
                penBack.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                graphics.DrawLine(penBack, new Point(Coordinate.X - 2, Coordinate.Y - 2), new Point(Coordinate.X + Coordinate.Width + 2, Coordinate.Y - 2));
                graphics.DrawLine(penBack, new Point(Coordinate.X - 2, Coordinate.Y - 2), new Point(Coordinate.X - 2, Coordinate.Bottom + 2));
                graphics.DrawLine(penBack, new Point(Coordinate.X + Coordinate.Width + 2, Coordinate.Y - 2), new Point(Coordinate.X + Coordinate.Width + 2, Coordinate.Bottom + 2));
                graphics.DrawLine(penBack, new Point(Coordinate.X - 2, Coordinate.Bottom + 2), new Point(Coordinate.X + Coordinate.Width + 2, Coordinate.Bottom + 2));
            }
        }
    }
}
