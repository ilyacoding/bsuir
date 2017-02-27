using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP
{
    public class ShapeList
    {
        public Point OldPoint { get; set; }
        public Point CurrentPoint { get; set; }
        public bool DrawingPoint { get; set; }
        public Shape ShapeToDraw { get; set; }
        public Color BackColor { get; set; }

        public List<Shape> list { get; set; }
        public List<Shape> listHistory { get; set; }

        public ShapeList(Color color)
        {
            list = new List<Shape>();
            OldPoint = new Point(0, 0);
            CurrentPoint = new Point(0, 0);
            DrawingPoint = new bool();
            DrawingPoint = false;
            BackColor = color;
        }

        public void Add(Shape shape)
        {
            list.Add(shape);
        }

        public void Draw(Graphics graphics)
        {
            foreach (var sh in list)
            {
                sh.Draw(graphics);
            }
        }

        public void Clear(Graphics graphics)
        {
            list.Clear();
            graphics.Clear(BackColor);
        }

        public void ReDraw(Graphics graphics)
        {
            graphics.Clear(BackColor);
            this.Draw(graphics);
        }

        public void DrawTmp(Graphics graphics)
        {
            ShapeToDraw.Draw(graphics);
        }

        public void Back(Graphics graphics)
        {
            if (list.Count > 0)
            {
                graphics.Clear(BackColor);
                list.Remove(list.Last());
                this.Draw(graphics);
            }
        }
    }
}
