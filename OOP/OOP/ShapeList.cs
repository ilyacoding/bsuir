using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class ShapeList
    {
        public ShapeList()
        {
            list = new List<Shape>();
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
        public void Clear()
        {
            list.Clear();
        }
        private List<Shape> list;
    }
}
