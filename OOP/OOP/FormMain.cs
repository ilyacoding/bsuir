using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace OOP
{
    public partial class FormMain : Form
    {
        ShapeList Shapes;
        public FormMain()
        {
            InitializeComponent();
            panelColorSelect.BackColor = colorDialogSelect.Color;
            panelBackgroundSelect.BackColor = panelDraw.BackColor;
            Shapes = new ShapeList();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Shapes.Add(new Line(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 10, 20, 20, 180));
                Shapes.Add(new Ellipse(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 20, 0, 90, 180));
                Shapes.Add(new Rectangle(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 90, 10, 110, 19));
                Shapes.Add(new IsoTriangle(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 100, 100, 500, 200));
                Shapes.Add(new Triangle(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 220, 10, 290, 240));
                Shapes.Add(new Trapeze(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 10, 10, 40, 40));
             
                Shapes.Draw(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonColorSelect_Click(object sender, EventArgs e)
        {
            if (colorDialogSelect.ShowDialog() == DialogResult.OK)
            {
                panelColorSelect.BackColor = colorDialogSelect.Color;
            }
        }

        private void buttonThicknessMore_Click(object sender, EventArgs e)
        {
            labelThickness.Text = (Int32.Parse(labelThickness.Text) + 1).ToString();
        }

        private void buttonThicknessLess_Click(object sender, EventArgs e)
        {
            int currentThickness = Int32.Parse(labelThickness.Text);
            if (currentThickness > 1)
                labelThickness.Text = (currentThickness - 1).ToString();
        }

        private void buttonBackgroundSelect_Click(object sender, EventArgs e)
        {
            if (colorDialogBackground.ShowDialog() == DialogResult.OK)
            {
                panelBackgroundSelect.BackColor = colorDialogBackground.Color;
                panelDraw.BackColor = panelBackgroundSelect.BackColor;
            }
        }

        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (Shapes.ShapeToDraw == null)
            {
                MessageBox.Show("Please, select shape to draw.");
                return;
            }

            if (!Shapes.DrawingPoint)
            {
                Shapes.DrawingPoint = true;
                Shapes.OldPoint = new Point(e.X, e.Y);
            } else
            {
                Shapes.DrawingPoint = false;
                Shapes.CurrentPoint = new Point(e.X, e.Y);    
                Shapes.Add((Shape)Activator.CreateInstance(Shapes.ShapeToDraw.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X, Shapes.OldPoint.Y, Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y }));
                Shapes.Draw(this);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Shapes.ShapeToDraw = new Line(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 0, 0, 0, 0);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Shapes.ShapeToDraw = new Rectangle(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 0, 0, 0, 0);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Shapes.ShapeToDraw = new Ellipse(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 0, 0, 0, 0);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Shapes.ShapeToDraw = new Triangle(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 0, 0, 0, 0);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Shapes.ShapeToDraw = new IsoTriangle(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 0, 0, 0, 0);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            Shapes.ShapeToDraw = new Trapeze(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 0, 0, 0, 0);
        }

        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (Shapes.DrawingPoint)
            {
                Shapes.CurrentPoint = new Point(e.X, e.Y);
                Shapes.ShapeToDraw = (Shape)Activator.CreateInstance(Shapes.ShapeToDraw.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X, Shapes.OldPoint.Y, Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y });
                Shapes.ReDraw(this);
                Shapes.DrawTmp(this);
            }
        }

        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            panelDraw.Width += 10;
        }
        

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shapes.Back(this);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shapes.Clear(this);
        }
    }
}
