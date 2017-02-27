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
            ShapeButton btn = (ShapeButton)sender;
            Shapes.ShapeToDraw = (Shape)Activator.CreateInstance(btn.TypeOfShape, new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 0, 0, 0, 0 });
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
            //MessageBox.Show(json);
            //var x = BsonDocument.Create(Shapes.ToBsonDocument());
            //var y = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<ShapeList>(x);
            //var x = MongoDB.Bson.Serialization.BsonSerializer.Serialize(Shapes, Formatting.Indented);
            //var x = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(json);
            //MessageBox.Show(json);            
            //ShapeList ls = JsonConvert.DeserializeObject<ShapeList>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            //Shapes.Clear(panelDraw.CreateGraphics(), panelDraw.BackColor);
            //Shapes = ls;
            //Shapes.Draw(panelDraw.CreateGraphics());

            /*                byte[] data = Bson.Serialize(Shapes.list);

                Shapes.Clear(panelDraw.CreateGraphics(), panelDraw.BackColor);

                Shapes = new ShapeList();
                Shapes.list = Bson.DeSerialize(data);*/

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
            int index = listBoxShapes.SelectedIndex;
           
            if (!(Shapes[index] is ISelectable))
            {
                listBoxShapes.ClearSelected();
                //MessageBox.Show("You can't select this shape type.");
            }
            else
            {
                Shapes.Select(index);
                Shapes.ReDraw(panelDraw.CreateGraphics());
            }

        }

        private void buttonEditShape_Click(object sender, EventArgs e)
        {
            var Shape = listBoxShapes.SelectedItem;
            if (Shape != null)
            {
                if (Shape is IEditable)
                {
                    
                }
                else
                {
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
