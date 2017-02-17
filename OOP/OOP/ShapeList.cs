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
        public void Draw(FormMain form)
        {
            foreach (Shape sh in list)
            {
                sh.Draw(form);
            }
        }

        public void Clear(FormMain form)
        {
            list.Clear();
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.Clear(form.panelDraw.BackColor);
        }

        public void ReDraw(FormMain form)
        {
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.Clear(form.panelDraw.BackColor);
            this.Draw(form);
        }

        public void DrawTmp(FormMain form)
        {
            ShapeToDraw.Draw(form);
        }

        public void Back(FormMain form)
        {
            if (list.Count > 0)
            {
                System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
                graphics.Clear(form.panelDraw.BackColor);
                list.Remove(list.Last());
                this.Draw(form);
            }
        }

        public Point OldPoint { get; set; }
        public Point CurrentPoint { get; set; }
        public bool DrawingPoint { get; set; }

        public Shape ShapeToDraw { get; set; }
        //public Type ShapeType { get; set; }
        private List<Shape> list;
    }
}
