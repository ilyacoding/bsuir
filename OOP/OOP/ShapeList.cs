using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace OOP
{
    public enum EState
    {
        ReadyDrawing, Drawing, Editing, Moving, None
    }

    public class ShapeList
    {
        public Color BackColor { get; set; }

        public Point OldPoint { get; set; }
        public Point CurrentPoint { get; set; }
        public EState State { get; set; }
        public Shape ShapeToWork { get; set; }

        public List<Shape> list { get; set; }

        private ListBox lb { get; set; }

        public ShapeList(Color color, ListBox listBox)
        {
            list = new List<Shape>();
            OldPoint = new Point(0, 0);
            CurrentPoint = new Point(0, 0);
            State = new EState();
            State = EState.None;
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

        public void Select(int index, Graphics graphics)
        {
            if (index >= 0 && index < list.Count)
            {
                UnSelect(graphics);
                (list[index] as ISelectable).Selected = true;
                ShapeToWork = list[index];
                list.RemoveAt(index);
            }
        }

        public void UnSelect(Graphics graphics)
        {
                foreach (var sh in list)
                {
                    if (sh is ISelectable)
                    {
                        (sh as ISelectable).Selected = false;
                    }
                }
            ReDraw(graphics);
        }

        public void ReDraw(Graphics graphics)
        {
            graphics.Clear(BackColor);
            this.Draw(graphics);
            RefreshListBox();
        }

        public void DrawTmp(Graphics graphics)
        {
            ShapeToWork.Draw(graphics);
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
