using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Microsoft.VisualBasic;
using ShapeContract;
using System.Xml;

namespace OOP
{
    public partial class FormMain : Form
    {
        private ShapeList Shapes;
        private ConfigSettings Settings;
        private Layer Layers;
        private CompositionContainer container;
        private ImportManager imports;
        private KnownTypesBinder kBinder;
        private string ExecutionPath { get; set; }
        private ConfigSettings ConfigSettings { get; set; }
        private ConfigSerializer ConfigSerializer { get; set; }

        private int InstrumentButtonY = 1;

        public FormMain()
        {
            InitializeComponent();
            ExecutionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            panelColorSelect.BackColor = Color.Black;
            panelBackgroundSelect.BackColor = Color.White;
            pictureBoxDraw.BackColor = Color.White;
            DoubleBuffered = true;

            Shapes = new ShapeList(Color.White, listBoxShapes);
            Layers = new Layer(pictureBoxDraw.Width, pictureBoxDraw.Height, Shapes);
            kBinder = new KnownTypesBinder();
            ConfigSerializer = new ConfigSerializer();
        }

        private void InitializeImport(string directoryPath)
        {
            var dirCatalog = new DirectoryCatalog(directoryPath);
            container = new CompositionContainer(dirCatalog);
            imports = new ImportManager();
            container.ComposeParts(this, imports);
        }

        public T Clone<T>(T source)
        { 
            var serialized = JsonConvert.SerializeObject(source, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Binder = kBinder
            });
            return JsonConvert.DeserializeObject<T>(serialized, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Binder = kBinder
            });
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

        private void InstrumentButton_Click(object sender, EventArgs e)
        {
            if (Shapes.State == EState.None)
            {
                Shapes.State = EState.ReadyDrawing;
                var btn = (InstrumentButton)sender;
                var instrument = new Instrument(colorDialogSelect.Color, Int32.Parse(labelThickness.Text), 0, 0, 0, 0, Clone(btn.Instrument.ShapesList));
                
                Shapes.ShapeToWork = (Shape)instrument;
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
            if (ConfigSettings == null)
            {
                MessageBox.Show("Config wasn't load.");
                return;
            }
            saveFileDialog.Filter = "Image files (*." + ConfigSettings.ImageSettings.ImageExtension + ")|*." + ConfigSettings.ImageSettings.ImageExtension;
            saveFileDialog.InitialDirectory = ConfigSettings.ImageSettings.ImagePath;
            saveFileDialog.RestoreDirectory = false;
            
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(Shapes, new JsonSerializerSettings {
                        TypeNameHandling = TypeNameHandling.All,
                        Binder = kBinder
                    });
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
            ClearFileDialog();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigSettings == null)
            {
                MessageBox.Show("Config wasn't load.");
                return;
            }
            openFileDialog.Filter = "Image files (*." + ConfigSettings.ImageSettings.ImageExtension + ")|*." + ConfigSettings.ImageSettings.ImageExtension;
            openFileDialog.InitialDirectory = ConfigSettings.ImageSettings.ImagePath;
            openFileDialog.RestoreDirectory = false;
            
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    string json = File.ReadAllText(openFileDialog.FileName);

                    Shapes = JsonConvert.DeserializeObject<ShapeList>(json, new JsonSerializerSettings {
                        TypeNameHandling = TypeNameHandling.All,
                        Binder = kBinder
                    });
                    Shapes.SetListBox(listBoxShapes);
                    Layers = new Layer(pictureBoxDraw.Width, pictureBoxDraw.Height, Shapes);
                    Shapes.RefreshListBox();
                    panelBackgroundSelect.BackColor = Shapes.BackColor;
                    Layers.UpdateStatic();
                    pictureBoxDraw.Image = Layers.DynamicLayer;
                }
                catch (JsonSerializationException)
                {
                    MessageBox.Show("Can't find some shapes, contained in image. Please, load them.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error while reading file.");
                }
            }
            ClearFileDialog();
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
                if (Shapes.ShapeToWork is Instrument)
                {   
                    Shapes.ShapeToWork = (Shape)Activator.CreateInstance(Shapes.ShapeToWork.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X, Shapes.OldPoint.Y, Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y, Clone((Shapes.ShapeToWork as Instrument).ShapesList) });
                }
                else
                {
                    Shapes.ShapeToWork = (Shape)Activator.CreateInstance(Shapes.ShapeToWork.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X, Shapes.OldPoint.Y, Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y });
                }

                Layers.UpdateDynamic();
                pictureBoxDraw.Image = Layers.DynamicLayer;
            }
            else if (Shapes.State == EState.Moving)
            {
                Shapes.CurrentPoint = new Point(e.X, e.Y);
                if (Shapes.ShapeToWork is Instrument)
                {
                    Shapes.ShapeToWork = (Shape)Activator.CreateInstance(Shapes.ShapeToWork.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), e.X, e.Y, e.X + Shapes.ShapeToWork.Coordinate.Width, e.Y + Shapes.ShapeToWork.Coordinate.Height, Clone((Shapes.ShapeToWork as Instrument).ShapesList) });
                }
                else
                {
                    Shapes.ShapeToWork = (Shape)Activator.CreateInstance(Shapes.ShapeToWork.GetType(), new object[] { colorDialogSelect.Color, Int32.Parse(labelThickness.Text), e.X, e.Y, e.X + Shapes.ShapeToWork.Coordinate.Width, e.Y + Shapes.ShapeToWork.Coordinate.Height });
                }

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
            
            switch (Shapes.State)
            {
                case EState.ReadyDrawing:
                    Shapes.State = EState.Drawing;
                    Shapes.OldPoint = new Point(e.X, e.Y);
                    Layers.UpdateStatic();
                    pictureBoxDraw.Image = Layers.DynamicLayer;
                    break;
                case EState.Drawing:
                    Shapes.State = EState.None;
                    Shapes.CurrentPoint = new Point(e.X, e.Y);

                    object[] argArray;

                    if (Shapes.ShapeToWork is Instrument)
                    {
                        argArray = new object[]
                        {
                            colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X,
                            Shapes.OldPoint.Y,
                            Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y,
                            Clone((Shapes.ShapeToWork as Instrument).ShapesList)
                        };
                    }
                    else
                    {
                        argArray = new object[]
                        {
                            colorDialogSelect.Color, Int32.Parse(labelThickness.Text), Shapes.OldPoint.X,
                            Shapes.OldPoint.Y,
                            Shapes.CurrentPoint.X, Shapes.CurrentPoint.Y
                        };
                    }
                    Shapes.Add((Shape)Activator.CreateInstance(Shapes.ShapeToWork.GetType(), argArray));

                    Shapes.ShapeToWork = null;
                    Layers.UpdateStatic();
                    pictureBoxDraw.Image = Layers.DynamicLayer;
                    break;
                case EState.Moving:
                    Shapes.State = EState.None;
                    Shapes.Add(Shapes.ShapeToWork);
                    Shapes.ShapeToWork = null;
                    Layers.UpdateStatic();
                    pictureBoxDraw.Image = Layers.DynamicLayer;
                    break;
            }
        }
        
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigSettings == null)
            {
                MessageBox.Show("Config wasn't load.");
                return;
            }
            try
            {
                InitializeImport(ConfigSettings.ModuleSettings.ModulePath);

                var y = 1;
                var runtimeTypes = new List<Type>();
                foreach (var extension in imports.readerExtCollection)
                {
                    try
                    {
                        var btn = new ShapeButton();
                        btn.Text = extension.Value.GetType().ToString().Split('.')[0];
                        btn.Location = new Point(5, 22 * (y++));
                        btn.TypeOfShape = extension.Value.GetType();
                        btn.Click += new EventHandler(ShapeButton_Click);
                        groupBoxShape.Controls.Add(btn);

                        runtimeTypes.Add(extension.Value.GetType());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                runtimeTypes.Add(Shapes.GetType());
                runtimeTypes.Add(Shapes.list.GetType());
                runtimeTypes.Add(typeof(Instrument));

                kBinder.KnownTypes = runtimeTypes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ClearFileDialog();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ConfigSettings == null)
            {
                MessageBox.Show("Config wasn't load.");
                return;
            }
            saveFileDialog.Filter = "Instrument files (*." + ConfigSettings.InstrumentSettings.InstrumentExtension + ")|*." + ConfigSettings.InstrumentSettings.InstrumentExtension;
            saveFileDialog.InitialDirectory = ConfigSettings.InstrumentSettings.InstrumentPath;
            saveFileDialog.RestoreDirectory = false;
            
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                var Name = Interaction.InputBox("Instrument name:", "Input name", "");
                try
                {
                    var instrument = Shapes.GetInstrument(pictureBoxDraw.Width, pictureBoxDraw.Height);

                    instrument.Name = Name;
                    var json = JsonConvert.SerializeObject(instrument, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Newtonsoft.Json.Formatting.Indented,
                        Binder = kBinder
                    });
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

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ConfigSettings == null)
            {
                MessageBox.Show("Config wasn't load.");
                return;
            }
            openFileDialog.Filter = "Instrument files (*." + ConfigSettings.InstrumentSettings.InstrumentExtension + ")|*." + ConfigSettings.InstrumentSettings.InstrumentExtension;
            openFileDialog.InitialDirectory = ConfigSettings.InstrumentSettings.InstrumentPath;
            openFileDialog.RestoreDirectory = false;
            
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    var json = File.ReadAllText(openFileDialog.FileName);

                    var instrument = JsonConvert.DeserializeObject<Instrument>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Binder = kBinder
                    });

                    try
                    {
                        var btn = new InstrumentButton();
                        btn.Text = instrument.Name;
                        btn.Location = new Point(5, 22 * (InstrumentButtonY++));
                        btn.Instrument = instrument;
                        btn.Click += new EventHandler(InstrumentButton_Click);
                        groupBoxInstruments.Controls.Add(btn);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                catch (JsonSerializationException)
                {
                    MessageBox.Show("Can't find some shapes, contained in image. Please, load them.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error while reading file.");
                }
            }
        }

        private void loadToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Xml configuration (*.xml)|*.xml";
            openFileDialog.InitialDirectory = Path.Combine(ExecutionPath, "Configurations");
            openFileDialog.RestoreDirectory = false;
            
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                ConfigSettings = ConfigSerializer.Deserialize(openFileDialog.FileName);

                if (!ConfigSettings.IsValid())
                {
                    ConfigSettings = null;
                    MessageBox.Show("Invalid config.");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid config.");
                return;
            }

            pictureBoxDraw.Width = ConfigSettings.WindowSettings.Width;
            pictureBoxDraw.Height = ConfigSettings.WindowSettings.Height;

            Layers = new Layer(pictureBoxDraw.Width, pictureBoxDraw.Height, Shapes);

            labelConfig.Text = "Config: " + Path.GetFileName(openFileDialog.FileName);
            ClearFileDialog();
        }

        private void configurationEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formSetttings = new FormSettings(new ConfigSerializer());
            formSetttings.Show();
        }

        private void ClearFileDialog()
        {
            openFileDialog.FileName = "";
            saveFileDialog.FileName = "";
        }
    }
}