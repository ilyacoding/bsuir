using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace OOP
{
    public partial class FormSettings : Form
    {
        private ConfigSerializer ConfigSerializer { get; set; }
        private string ExecutionPath { get; set; }
        public FormSettings(ConfigSerializer configSerializer)
        {
            InitializeComponent();
            ConfigSerializer = configSerializer;
            ExecutionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int width;
            int height;
            
            string modulePath;

            string imageExtension;
            string imagePath;

            string instrumentExtension;
            string instrumentPath;
            
            try
            {
                width = Convert.ToInt32(textBoxWidth.Text);
                height = Convert.ToInt32(textBoxHeight.Text);
                
                modulePath = textBoxModulePath.Text;


                imageExtension = textBoxImageExt.Text;
                imagePath = textBoxImagePath.Text;

                instrumentExtension = textBoxInstrumentExt.Text;
                instrumentPath = textBoxInstrumentPath.Text;

                if (modulePath.Length == 0) throw new Exception("Invalid modulePath");
                if (imagePath.Length == 0) throw new Exception("Invalid imagePath");
                if (imageExtension.Length == 0) throw new Exception("Invalid imageExtension");
                if (instrumentExtension.Length == 0) throw new Exception("Invalid instrumentExtension");
                if (instrumentPath.Length == 0) throw new Exception("Invalid instrumentPath");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            saveFileDialogConfig.Filter = "Xml configuration (*.xml)|*.xml";
            saveFileDialogConfig.InitialDirectory = ExecutionPath + "\\Configurations";

            if (saveFileDialogConfig.ShowDialog() == DialogResult.Cancel) return;

            var config = new ConfigSettings()
            {
                WindowSettings = new WindowSettings()
                {
                    Width = width,
                    Height = height
                },

                ModuleSettings = new ModuleSettings()
                {
                    ModulePath = modulePath
                },

                ImageSettings = new ImageSettings()
                {
                    ImageExtension = imageExtension,
                    ImagePath = imagePath
                },
                    
                InstrumentSettings = new InstrumentSettings()
                {
                    InstrumentExtension = instrumentExtension,
                    InstrumentPath = instrumentPath
                }
            };

            ConfigSerializer.Serialize(config, saveFileDialogConfig.FileName);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogConfig.Filter = "Xml configuration (*.xml)|*.xml";
            openFileDialogConfig.InitialDirectory = ExecutionPath + "\\Configurations";

            if (openFileDialogConfig.ShowDialog() == DialogResult.Cancel) return;

            var configSettings = ConfigSerializer.Deserialize(openFileDialogConfig.FileName);

            textBoxHeight.Text = configSettings.WindowSettings.Height.ToString();
            textBoxWidth.Text = configSettings.WindowSettings.Width.ToString();

            textBoxModulePath.Text = configSettings.ModuleSettings.ModulePath;

            textBoxImagePath.Text = configSettings.ImageSettings.ImagePath;
            textBoxImageExt.Text = configSettings.ImageSettings.ImageExtension;

            textBoxInstrumentPath.Text = configSettings.InstrumentSettings.InstrumentPath;
            textBoxInstrumentExt.Text = configSettings.InstrumentSettings.InstrumentExtension;
        }

        private void textBoxModulePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialogPath.SelectedPath = ExecutionPath;
            if (folderBrowserDialogPath.ShowDialog() != DialogResult.OK) return;

            textBoxModulePath.Text = folderBrowserDialogPath.SelectedPath;
        }

        private void textBoxInstrumentPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialogPath.SelectedPath = ExecutionPath;
            if (folderBrowserDialogPath.ShowDialog() != DialogResult.OK) return;

            textBoxInstrumentPath.Text = folderBrowserDialogPath.SelectedPath;
        }

        private void textBoxImagePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialogPath.SelectedPath = ExecutionPath;
            if (folderBrowserDialogPath.ShowDialog() != DialogResult.OK) return;

            textBoxImagePath.Text = folderBrowserDialogPath.SelectedPath;
        }
    }
}
