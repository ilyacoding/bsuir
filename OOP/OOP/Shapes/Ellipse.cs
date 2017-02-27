﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP
{
    public class Ellipse : Shape, ISelectable, IEditable
    {
        public bool Selected { get; set; }
        public bool Editing { get; set; }
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
