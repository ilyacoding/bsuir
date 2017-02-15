﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Rectangle : Shape
    {
        public Rectangle(int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2, y2);
        }
        public override void Draw(FormMain form)
        {
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawRectangle(System.Drawing.Pens.Red, Coordinate);
        }
    }
}
