using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ShapeContract;

namespace OOP
{
    public enum EState
    {
        ReadyDrawing, Drawing, ReadyEditing, Moving, None
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
            get {
                if (index >= 0 && index < list.Count)
                    return list[index];

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
                sh.Draw(graphics, null);
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

        public void DrawTmp(Graphics graphics)
        {
            ShapeToWork?.Draw(graphics, null);
        }

        public void RefreshListBox()
        {
            lb.Items.Clear();
            foreach (var shape in list)
            {
                lb.Items.Add(shape);
            }
        }

        public void SetListBox(ListBox listBox)
        {
            lb = listBox;
        }

        public void Back()
        {
            if (list.Count <= 0) return;
            list.Remove(list.Last());
            RefreshListBox();
        }

        public Instrument GetInstrument(int width, int height)
        {
            var result = new Instrument();
            var content = new List<Shape>(0);
            foreach (var element in list)
            {
                if (element is Instrument)
                {
                    foreach (var shape in (element as Instrument).ShapesList)
                    {
                        var coord = shape.Coordinate;
                        coord = CoordinateConvertor.ToReal(coord, element.Coordinate.X, element.Coordinate.Y, element.Coordinate.Width, element.Coordinate.Height);
                        coord = CoordinateConvertor.ToDelta(coord, width, height);
                        shape.Coordinate = coord;
                        content.Add(shape);
                    }
                }
                else
                {
                    element.Coordinate = CoordinateConvertor.ToDelta(element.Coordinate, width, height);
                    content.Add(element);
                }
            }
            result.ShapesList = content;
            return result;
        }
    }
}