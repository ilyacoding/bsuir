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
        public static Shape ToDelta(Shape shape, int width, int height)
        {
            var coordRectangle = new Rectangle(shape.Coordinate.X, shape.Coordinate.Y, shape.Coordinate.Width, shape.Coordinate.Height);
            coordRectangle.X = coordRectangle.X * 1000 / width;
            coordRectangle.Y = coordRectangle.Y * 1000 / height;
            coordRectangle.Width = coordRectangle.Width * 1000 / width;
            coordRectangle.Height = coordRectangle.Height * 1000 / height;
            shape.Coordinate = coordRectangle;
            return shape;
        }

        public static Shape ToReal(Shape shape, int x, int y, int width, int height)
        {
            var coordRectangle = new Rectangle(shape.Coordinate.X, shape.Coordinate.Y, shape.Coordinate.Width, shape.Coordinate.Height);
            coordRectangle.X = coordRectangle.X * width / 1000 + x;
            coordRectangle.Y = coordRectangle.Y * height / 1000 + y;
            coordRectangle.Width = coordRectangle.Width * width / 1000;
            coordRectangle.Height = coordRectangle.Height * height / 1000;
            shape.Coordinate = coordRectangle;
            return shape;
        }
    }
}
