using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;

namespace OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panelColorSelect.BackColor = colorDialogSelect.Color;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            List<Shape> Shapes = new List<Shape>(1);
            //Shapes.Add(new Rectangle(0, 0, 100, 100));
            //Shapes.Add(new Ellipse(20, 20, 180, 90));
            Shapes.Add(new Line(colorDialogSelect.Color, 0, 20, 90, 30));
            //Shapes.Add(new Pie(0,0,10,10));
            //Shapes.Add(new Triangle(0, 0, 100, 100));
            //Shapes.Add(new Rhombus(0, 0, 100, 100));
            foreach (Shape sh in Shapes)
            {
                sh.Draw(this);
            }
        }

        private void buttonColorSelect_Click(object sender, EventArgs e)
        {
            if (colorDialogSelect.ShowDialog() == DialogResult.OK)
            {
                panelColorSelect.BackColor = colorDialogSelect.Color;
            }
        }
    }

    public class Shape
    {
        public System.Drawing.Rectangle Coordinate { get; set; }
        public System.Drawing.Pen Pen { get; set; }
        public virtual void Draw(Form1 form) { }
    }

    public class Line : Shape
    {
        public Line(System.Drawing.Color color, int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2, y2);
            Pen = new Pen(color);
            //Pen.color = color;
        }
        public override void Draw(Form1 form)
        {
            //Coordinate.X
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawLine(Pen, new Point(Coordinate.X, Coordinate.Y), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom));
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2, y2);
        }
        public override void Draw(Form1 form)
        {
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawRectangle(System.Drawing.Pens.Red, Coordinate);
        }
    }

    public class Ellipse : Shape
    {
        public Ellipse(int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2, y2);
        }
        public override void Draw(Form1 form)
        {
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawEllipse(System.Drawing.Pens.Red, Coordinate);
        }
    }

    public class Pie : Shape
    {
        public Pie(int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2, y2);
        }
        public override void Draw(Form1 form)
        {
            float startAngle = 0.0F;
            float sweepAngle = 90.0F;
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawPie(System.Drawing.Pens.Red, Coordinate, startAngle, sweepAngle);
        }
    }

    public class Triangle : Shape
    {
        public Triangle(int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2, y2);
        }
        public override void Draw(Form1 form)
        {
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawLine(System.Drawing.Pens.Red, new Point(Coordinate.X, Coordinate.Y), new Point(Coordinate.X, Coordinate.Bottom));
            graphics.DrawLine(System.Drawing.Pens.Red, new Point(Coordinate.X, Coordinate.Y), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom));
            graphics.DrawLine(System.Drawing.Pens.Red, new Point(Coordinate.X, Coordinate.Bottom), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom));
        }
    }

    public class Rhombus : Shape
    {
        public Rhombus(int x1, int y1, int x2, int y2)
        {
            Coordinate = new System.Drawing.Rectangle(x1, y1, x2, y2);
        }
        public override void Draw(Form1 form)
        {
            System.Drawing.Graphics graphics = form.panelDraw.CreateGraphics();
            graphics.DrawLine(System.Drawing.Pens.Red, new Point((Coordinate.X + Coordinate.Width) / 2, Coordinate.Y), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom / 2));
            graphics.DrawLine(System.Drawing.Pens.Red, new Point((Coordinate.X + Coordinate.Width) / 2, Coordinate.Y), new Point(Coordinate.X, Coordinate.Bottom / 2));
            graphics.DrawLine(System.Drawing.Pens.Red, new Point(Coordinate.X, Coordinate.Bottom / 2), new Point((Coordinate.X + Coordinate.Width) / 2, Coordinate.Bottom));
            graphics.DrawLine(System.Drawing.Pens.Red, new Point((Coordinate.X + Coordinate.Width) / 2, Coordinate.Bottom), new Point(Coordinate.X + Coordinate.Width, Coordinate.Bottom / 2));
         }
    }
}
