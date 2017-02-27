using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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

        private ListBox lb { get; set; }

        public ShapeList(Color color, ListBox listBox)
        {
            list = new List<Shape>();
            OldPoint = new Point(0, 0);
            CurrentPoint = new Point(0, 0);
            DrawingPoint = new bool();
            DrawingPoint = false;
            BackColor = color;
            lb = listBox;
        }

        public Shape this[int index]
        {
            get { if (index >= 0 && index < list.Count)
                    return list[index];
                else
                    return null;
                }
        }

        public void Add(Shape shape)
        {
            list.Add(shape);
            RefreshListBox();
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
            RefreshListBox();
        }

        public void Select(int index)
        {
            if (index >= 0 && index < list.Count)
            {
                foreach (var sh in list)
                {
                    if (sh is ISelectable)
                    {
                        (sh as ISelectable).Selected = false;
                    }
                }
                (list[index] as ISelectable).Selected = true;
            }
        }

        public void ReDraw(Graphics graphics)
        {
            graphics.Clear(BackColor);
            this.Draw(graphics);
            RefreshListBox();
        }

        public void DrawTmp(Graphics graphics)
        {
            ShapeToDraw.Draw(graphics);
        }

        private void RefreshListBox()
        {
            lb.Items.Clear();
            foreach (var Shape in list)
            {
                lb.Items.Add(Shape);
            }
        }

        public void SetListBox(ListBox listBox)
        {
            lb = listBox;
        }

        public void Back(Graphics graphics)
        {
            if (list.Count > 0)
            {
                graphics.Clear(BackColor);
                list.Remove(list.Last());
                this.Draw(graphics);
                RefreshListBox();
            }
        }
    }
}
