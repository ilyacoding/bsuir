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

namespace OOP
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            panelColorSelect.BackColor = colorDialogSelect.Color;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            var Shapes = new ShapeList();

            Shapes.Add(new Line(colorDialogSelect.Color, 0, 0, 20, 180));
            Shapes.Add(new Ellipse(colorDialogSelect.Color, 20, 0, 90, 180));
            Shapes.Add(new Rectangle(colorDialogSelect.Color, 90, 10, 110, 19));
            Shapes.Add(new Pie(colorDialogSelect.Color, 20, 0, 180, 220));
            Shapes.Add(new Triangle(colorDialogSelect.Color, 220,10,290,200));
            Shapes.Add(new Trapeze(colorDialogSelect.Color, 10,10,40,40));
            Shapes.Draw(this);
            Shapes.Clear();
        }

        private void buttonColorSelect_Click(object sender, EventArgs e)
        {
            if (colorDialogSelect.ShowDialog() == DialogResult.OK)
            {
                panelColorSelect.BackColor = colorDialogSelect.Color;
            }
        }
    }
}
