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
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using MongoDB.Bson;
using System.Reflection;

namespace OOP
{
    public partial class FormMain : Form
    {
        ShapeList Shapes;
        public FormMain()
        {
            InitializeComponent();
            panelColorSelect.BackColor = Color.Black;
            panelBackgroundSelect.BackColor = Color.White;
            panelDraw.BackColor = Color.White;
            Shapes = new ShapeList(Color.White, listBoxShapes);

            Type ClassType = typeof(Shape);
            int y = 1;
            IEnumerable<Type> list = Assembly.GetAssembly(ClassType).GetTypes().Where(type => type.IsSubclassOf(ClassType)); 
            foreach (Type itm in list)
            {
                ShapeButton btn = new ShapeButton();
                btn.Text = itm.Name;
                btn.Location = new Point(5, 22*(y++));
                btn.TypeOfShape = itm;
                btn.Click += new EventHandler(ShapeButton_Click);
                this.groupBoxShape.Controls.Add(btn);
            }
        }
       
        private void buttonColorSelect_Click(object sender, EventArgs e)
        {
            if (colorDialogSelect.ShowDialog() == DialogResult.OK)
            {
                panelColorSelect.BackColor = colorDialogSelect.Color;
            }
        }

        private void buttonBackgroundSelect_Click(object sender, EventArgs e)
        {
            if (colorDialogBackground.ShowDialog() == DialogResult.OK)
            {
                panelBackgroundSelect.BackColor = colorDialogBackground.Color;
                Shapes.BackColor = colorDialogBackground.Color;
                Shapes.ReDraw(panelDraw.CreateGraphics());
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

        private void ShapeButton_Click(object sender, EventArgs e)
        {
            if (Shapes.State == EState.None)
            {
                Shapes.State = EState.ReadyDrawing;
                ShapeButton btn = (ShapeButton)sender;
                Shapes.ShapeToWork = (Shape)Activator.CreateInstance(btn.TypeOfShape, new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 0, 0, 0, 0 });
            }
        }

        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (Shapes.ShapeToWork == null)
            {
                MessageBox.Show("Please, select shape to draw.");
                return;
            }

            if (Shapes.State == EState.ReadyDrawing)
            {
                Shapes.State = EState.Drawing;
                Shapes.OldPoint = new Point(e.X, e.Y);
            }
            else if (Shapes.State == EState.Drawing)
            {
                Shapes.State = EState.None;
                Shapes.CurrentPoint = new Point(e.X, e.Y);
                Shapes.Add((Shape)Activator.CreateInstance(Shapes.ShapeToWork.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X, Shapes.OldPoint.Y, Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y }));
                Shapes.ShapeToWork = null;
                Shapes.Draw(this.panelDraw.CreateGraphics());
            }
            else if (Shapes.State == EState.Moving)
            {
                Shapes.State = EState.None;
                Shapes.Add(Shapes.ShapeToWork);
                Shapes.ShapeToWork = null;
                Shapes.ReDraw(this.panelDraw.CreateGraphics());
            }
        }

        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (Shapes.State == EState.Drawing)
            {
                Shapes.CurrentPoint = new Point(e.X, e.Y);
                Shapes.ShapeToWork = (Shape)Activator.CreateInstance(Shapes.ShapeToWork.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X, Shapes.OldPoint.Y, Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y });
                Shapes.ReDraw(this.panelDraw.CreateGraphics());
                Shapes.DrawTmp(this.panelDraw.CreateGraphics());
            }
            else if (Shapes.State == EState.Moving)
            {
                Shapes.CurrentPoint = new Point(e.X, e.Y);
                Shapes.ShapeToWork = (Shape)Activator.CreateInstance(Shapes.ShapeToWork.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), e.X, e.Y, e.X + Shapes.ShapeToWork.Coordinate.Width, e.Y + Shapes.ShapeToWork.Coordinate.Height });
                Shapes.ReDraw(this.panelDraw.CreateGraphics());
                Shapes.DrawTmp(this.panelDraw.CreateGraphics());
            }
        }

        private void backToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Shapes.Back(this.panelDraw.CreateGraphics());
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Shapes.Clear(this.panelDraw.CreateGraphics());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    string json = JsonConvert.SerializeObject(Shapes, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    File.WriteAllText(saveFileDialog.FileName, json);
                    Shapes.Clear(panelDraw.CreateGraphics());
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while writing to file. Err: " + err.ToString());
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    string json = File.ReadAllText(openFileDialog.FileName);
                    Shapes = JsonConvert.DeserializeObject<ShapeList>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    Shapes.SetListBox(listBoxShapes);
                    Shapes.ReDraw(panelDraw.CreateGraphics());
                    panelBackgroundSelect.BackColor = Shapes.BackColor;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while reading file. Err: " + err.ToString());
                }
            }
        }

        private void listBoxShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Shapes.State == EState.None || Shapes.State == EState.ReadyEditing)
            {
                int index = listBoxShapes.SelectedIndex;
                if (Shapes[index] is ISelectable)
                {
                    Shapes.State = EState.ReadyEditing;
                    if (Shapes.ShapeToWork != null)
                    {
                        Shapes.Add(Shapes.ShapeToWork);
                        Shapes.ShapeToWork = null;
                        Shapes.ReDraw(panelDraw.CreateGraphics());
                    }
                    Shapes.Select(index, panelDraw.CreateGraphics());
                    Shapes.ReDraw(panelDraw.CreateGraphics());
                    Shapes.DrawTmp(panelDraw.CreateGraphics());
                }
                else
                {
                    if (Shapes.ShapeToWork != null)
                    {
                        Shapes.Add(Shapes.ShapeToWork);
                    Shapes.ShapeToWork = null;
                        }
                    Shapes.UnSelect(panelDraw.CreateGraphics());
                }
            }
        }

        private void buttonEditShape_Click(object sender, EventArgs e)
        {
            if (Shapes.ShapeToWork != null)
            {
                if (Shapes.ShapeToWork is IEditable)
                {
                    Shapes.State = EState.Drawing;
                    Shapes.OldPoint = new Point(Shapes.ShapeToWork.Coordinate.X, Shapes.ShapeToWork.Coordinate.Y);
                }
                else
                {
                    Shapes.Add(Shapes.ShapeToWork);
                    Shapes.UnSelect(panelDraw.CreateGraphics());
                    Shapes.ShapeToWork = null;
                    Shapes.State = EState.None;
                    MessageBox.Show("You can't edit this shape type.");
                }
            }
            else
            {
                MessageBox.Show("Nothing selected.");
            }
        }

        private void buttonUnSelect_Click(object sender, EventArgs e)
        {
            if (Shapes.State == EState.ReadyEditing || Shapes.State == EState.Moving || Shapes.State == EState.Moving)
            {
                if (Shapes.ShapeToWork != null)
                {
                    Shapes.Add(Shapes.ShapeToWork);
                    Shapes.ShapeToWork = null;
                }
                Shapes.UnSelect(panelDraw.CreateGraphics());
                Shapes.State = EState.None;
            }
        }

        private void buttonMoveShape_Click(object sender, EventArgs e)
        {
            if (Shapes.ShapeToWork != null)
            {
                if (Shapes.ShapeToWork is IEditable)
                {
                    Shapes.State = EState.Moving;
                    
                }
                else
                {
                    Shapes.Add(Shapes.ShapeToWork);
                    Shapes.UnSelect(panelDraw.CreateGraphics());
                    Shapes.ShapeToWork = null;
                    Shapes.State = EState.None;
                    MessageBox.Show("You can't edit this shape type.");
                }
            }
            else
            {
                MessageBox.Show("Nothing selected.");
            }
        }
    }
}
