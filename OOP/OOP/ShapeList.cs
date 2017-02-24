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

        private List<Shape> list;

        public ShapeList()
        {
            list = new List<Shape>();
            OldPoint = new Point(0, 0);
            CurrentPoint = new Point(0, 0);
            DrawingPoint = new bool();
            DrawingPoint = false;
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
            //System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            //graphics.Clear(form.panelDraw.BackColor);
        }

        public void ReDraw(Graphics graphics, Color color)
        {
            //System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.Clear(color);
            this.Draw(graphics);
        }

        public void DrawTmp(Graphics graphics)
        {
            ShapeToDraw.Draw(graphics);
        }

        public void Back(Graphics graphics, Color color)
        {
            if (list.Count > 0)
            {
                //System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
                graphics.Clear(color);
                list.Remove(list.Last());
                this.Draw(graphics);
            }
        }

    }
}
