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
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using ShapeContract;

using Autofac;
using Autofac.Core;

namespace OOP
{
    public class AutofacContractResolver : DefaultContractResolver
    {
        private readonly Autofac.IContainer _container;
        private ImportManager imports;

        public AutofacContractResolver(Autofac.IContainer container)
        {
            _container = container;
        }
 
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            JsonObjectContract contract = base.CreateObjectContract(objectType);
            
            if (_container.IsRegistered(objectType))
            {
                contract.DefaultCreator = () => _container.Resolve(objectType);
            }
            return contract;
        }
    }

    public partial class FormMain : Form
    {
        ShapeList Shapes;
        Layer Layers;
        CompositionContainer container;
        static ImportManager imports;

        public FormMain()
        {
            InitializeComponent();
            panelColorSelect.BackColor = Color.Black;
            panelBackgroundSelect.BackColor = Color.White;
            pictureBoxDraw.BackColor = Color.White;
            DoubleBuffered = true;

            Shapes = new ShapeList(Color.White, listBoxShapes);
            Layers = new Layer(pictureBoxDraw.Width, pictureBoxDraw.Height, Shapes);
        }

        private void InitializeImport()
        {
            DirectoryCatalog dirCatalog = new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Plugins");
            container = new CompositionContainer(dirCatalog);
            imports = new ImportManager();
            container.ComposeParts(this, imports);
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
                
                Layers.UpdateStatic();
                pictureBoxDraw.Image = Layers.DynamicLayer;
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

        private void backToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Shapes.Back();
            Layers.UpdateStatic();
            pictureBoxDraw.Image = Layers.DynamicLayer;
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            Layers.UpdateStatic();
            pictureBoxDraw.Image = Layers.DynamicLayer;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    string json = JsonConvert.SerializeObject(Shapes, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    File.WriteAllText(saveFileDialog.FileName, json);
                    Shapes.Clear();
                    Layers.UpdateStatic();
                    pictureBoxDraw.Image = Layers.DynamicLayer;
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

                    ContainerBuilder builder = new ContainerBuilder();
                    foreach (var extension in imports.readerExtCollection)
                    {
                        builder.RegisterType(extension.Value.GetType());
                    }
                    Autofac.IContainer _container = builder.Build();

                    AutofacContractResolver contractResolver = new AutofacContractResolver(_container);

                    Shapes = JsonConvert.DeserializeObject<ShapeList>(json, new JsonSerializerSettings {
                        TypeNameHandling = TypeNameHandling.All
                    });
                    Shapes.SetListBox(listBoxShapes);
                    Layers = new Layer(pictureBoxDraw.Width, pictureBoxDraw.Height, Shapes);
                    Shapes.RefreshListBox();
                    panelBackgroundSelect.BackColor = Shapes.BackColor;
                    Layers.UpdateStatic();
                    pictureBoxDraw.Image = Layers.DynamicLayer;
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
                        Layers.UpdateStatic();
                    }
                    Shapes.UnSelect();
                    Shapes.Select(index);
                    Layers.UpdateStatic();
                    pictureBoxDraw.Image = Layers.DynamicLayer;
                }
                else
                {
                    if (Shapes.ShapeToWork != null)
                    {
                        Shapes.Add(Shapes.ShapeToWork);
                        Shapes.ShapeToWork = null;
                    }
                    Shapes.UnSelect();
                    Layers.UpdateStatic();
                    pictureBoxDraw.Image = Layers.DynamicLayer;
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
                    Shapes.UnSelect();
                    Layers.UpdateStatic();
                    pictureBoxDraw.Image = Layers.DynamicLayer;
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
                Shapes.UnSelect();
                Layers.UpdateStatic();
                pictureBoxDraw.Image = Layers.DynamicLayer;
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
                    Shapes.UnSelect();
                    Layers.UpdateStatic();
                    pictureBoxDraw.Image = Layers.DynamicLayer;
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

        private void pictureBoxDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (Shapes.State == EState.Drawing)
            {
                Shapes.CurrentPoint = new Point(e.X, e.Y);
                Shapes.ShapeToWork = (Shape)Activator.CreateInstance(Shapes.ShapeToWork.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X, Shapes.OldPoint.Y, Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y });
                Layers.UpdateDynamic();
                pictureBoxDraw.Image = Layers.DynamicLayer;
            }
            else if (Shapes.State == EState.Moving)
            {
                Shapes.CurrentPoint = new Point(e.X, e.Y);
                Shapes.ShapeToWork = (Shape)Activator.CreateInstance(Shapes.ShapeToWork.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), e.X, e.Y, e.X + Shapes.ShapeToWork.Coordinate.Width, e.Y + Shapes.ShapeToWork.Coordinate.Height });
                Layers.UpdateDynamic();
                pictureBoxDraw.Image = Layers.DynamicLayer;
            }
        }

        private void pictureBoxDraw_MouseDown(object sender, MouseEventArgs e)
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
                Layers.UpdateStatic();
                pictureBoxDraw.Image = Layers.DynamicLayer;
            }
            else if (Shapes.State == EState.Drawing)
            {
                Shapes.State = EState.None;
                Shapes.CurrentPoint = new Point(e.X, e.Y);
                Shapes.Add((Shape)Activator.CreateInstance(Shapes.ShapeToWork.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X, Shapes.OldPoint.Y, Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y }));
                Shapes.ShapeToWork = null;
                Layers.UpdateStatic();
                pictureBoxDraw.Image = Layers.DynamicLayer;
            }
            else if (Shapes.State == EState.Moving)
            {
                Shapes.State = EState.None;
                Shapes.Add(Shapes.ShapeToWork);
                Shapes.ShapeToWork = null;
                Layers.UpdateStatic();
                pictureBoxDraw.Image = Layers.DynamicLayer;
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeImport();
                int y = 1;
                foreach (var extension in imports.readerExtCollection)
                {
                    try
                    {
                        ShapeButton btn = new ShapeButton();
                        btn.Text = extension.Value.GetType().ToString().Split('.')[0];
                        btn.Location = new Point(5, 22 * (y++));
                        btn.TypeOfShape = extension.Value.GetType();
                        btn.Click += new EventHandler(ShapeButton_Click);
                        groupBoxShape.Controls.Add(btn);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
