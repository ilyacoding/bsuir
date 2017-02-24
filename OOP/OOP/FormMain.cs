using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

/*
        public string SerializeObjectToString<T>(this T objectToSerialize)
        {
            StringWriter outStream = new StringWriter();
            string value;
            try
            {
                XmlSerializer s = new XmlSerializer(objectToSerialize.GetType());
                s.Serialize(outStream, objectToSerialize);
                value = outStream.ToString();

MemoryStream ms = new MemoryStream();
                using (BsonWriter writer = new BsonWriter(ms))
                {
                    JsonSerializer serializer = new JsonSerializer();
serializer.Serialize(writer, objectToSerialize);
                }

                value = Convert.ToString(ms.ToArray());
            }
            finally
            {
                outStream.Close();
            }
            return value;
        }
*/

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

        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            panelDraw.Width += 10;
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
            }
            else
            {
                Shapes.DrawingPoint = false;
                Shapes.CurrentPoint = new Point(e.X, e.Y);
                Shapes.Add((Shape)Activator.CreateInstance(Shapes.ShapeToDraw.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X, Shapes.OldPoint.Y, Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y }));
                Shapes.Draw(this.panelDraw.CreateGraphics());
            }

        }

        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (Shapes.DrawingPoint)
            {
                Shapes.CurrentPoint = new Point(e.X, e.Y);
                Shapes.ShapeToDraw = (Shape)Activator.CreateInstance(Shapes.ShapeToDraw.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X, Shapes.OldPoint.Y, Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y });
                Shapes.ReDraw(this.panelDraw.CreateGraphics(), this.panelDraw.BackColor);
                Shapes.DrawTmp(this.panelDraw.CreateGraphics());
            }
        }

        private void backToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Shapes.Back(this.panelDraw.CreateGraphics(), this.panelDraw.BackColor);
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Shapes.Clear(this.panelDraw.CreateGraphics());

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var sh = new Trapeze(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 0, 0, 0, 0);

            MemoryStream ms = new MemoryStream();
            using(BsonWriter writer = new BsonWriter(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, Shapes);
            }
            string s = Convert.ToBase64String(ms.ToArray());
            MessageBox.Show(s);
            
        }
    }
}
