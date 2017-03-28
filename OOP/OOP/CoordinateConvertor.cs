using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeContract;

namespace OOP
{
    public static class CoordinateConvertor
    {
        public static Rectangle ToDelta(Rectangle coordShape, int width, int height)
        {
            var coordRectangle = new Rectangle(coordShape.X, coordShape.Y, coordShape.Width, coordShape.Height);
            coordRectangle.X = coordRectangle.X * 1000 / width;
            coordRectangle.Y = coordRectangle.Y * 1000 / height;
            coordRectangle.Width = coordRectangle.Width * 1000 / width;
            coordRectangle.Height = coordRectangle.Height * 1000 / height;
            return coordRectangle;
        }

        public static Rectangle ToReal(Rectangle coordShape, int x, int y, int width, int height)
        {
            var coordRectangle = new Rectangle(coordShape.X, coordShape.Y, coordShape.Width, coordShape.Height);
            coordRectangle.X = coordRectangle.X * width / 1000 + x;
            coordRectangle.Y = coordRectangle.Y * height / 1000 + y;
            coordRectangle.Width = coordRectangle.Width * width / 1000;
            coordRectangle.Height = coordRectangle.Height * height / 1000;
            return coordRectangle;
        }
    }
}
