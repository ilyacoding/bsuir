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
}
