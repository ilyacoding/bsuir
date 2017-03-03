using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using ShapeContract;

namespace OOP
{
    public enum EState
    {
        ReadyDrawing, Drawing, ReadyEditing, Editing, Moving, None
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

        public void Clear()
        {
            list.Clear();
            RefreshListBox();
        }

        public void Select(int index)
        {
            if (index >= 0 && index < list.Count)
            {
                (list[index] as ISelectable).Selected = true;
                ShapeToWork = list[index];
                list.RemoveAt(index);
            }
        }

        public void UnSelect()
        {
            foreach (var sh in list)
            {
                if (sh is ISelectable)
                {
                    (sh as ISelectable).Selected = false;
                }
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
            if (ShapeToWork != null)
            {
                ShapeToWork.Draw(graphics);
            }
        }

        public void RefreshListBox()
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

        public void Back()
        {
            if (list.Count > 0)
            {
                list.Remove(list.Last());
                RefreshListBox();
            }
        }
    }
}
