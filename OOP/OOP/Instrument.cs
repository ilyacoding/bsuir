using System.Collections.Generic;
using System.Drawing;
using ShapeContract;

namespace OOP
{
    public class Instrument : Shape, ISelectable, IEditable
    {
        public List<Shape> ShapesList { get; set; }
        public string Name { get; set; }

        public bool Editing { get; set; }
        public bool Selected { get; set; }

        public Instrument(Color color, float width, int x1, int y1, int x2, int y2, List<Shape> list)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2 - x1, y2 - y1);
            PenColor = color;
            PenWidth = width;
            ShapesList = new List<Shape>(list);
        }

        public Instrument()
        {
            Coordinate = new System.Drawing.Rectangle(0, 0, 0, 0);
            PenColor = Color.Black;
            PenWidth = 1;
            ShapesList = new List<Shape>();
        }

        public override void Draw(Graphics graphics, Pen pen)
        {
            if (pen == null)
                pen = new Pen(PenColor, PenWidth);

            var newList = new List<Shape>(ShapesList);

            foreach (var sh in newList)
            {
                var oldCoord = sh.Coordinate;
                sh.Coordinate = CoordinateConvertor.ToReal(sh.Coordinate, Coordinate.X, Coordinate.Y, Coordinate.Width, Coordinate.Height);
                sh.Draw(graphics, pen);
                sh.Coordinate = oldCoord;
            }

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
