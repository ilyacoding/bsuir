using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP
{
    public class Layer
    {
        public Bitmap DynamicLayer { get; set; }
        public ShapeList Shapes { get; set; }

        private Bitmap StaticLayer { get; set; }
        private int Width { get; set; }
        private int Height { get; set; }
        
        public Layer(int width, int height, ShapeList sh)
        {
            Width = width;
            Height = height;
            Shapes = sh;
        }
        
        public void UpdateStatic()
        {
            var TmpLayer = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(TmpLayer);
            graphics.Clear(Shapes.BackColor);
            Shapes.Draw(graphics);
            StaticLayer = (Bitmap)TmpLayer.Clone();
            UpdateDynamic();
        }

        public void UpdateDynamic()
        {
            Bitmap TmpLayer;
            if (StaticLayer != null)
            {
                TmpLayer = (Bitmap)StaticLayer.Clone();
            }
            else
            {
                TmpLayer = new Bitmap(Width, Height);
            }

            if (DynamicLayer != null)
            {
                DynamicLayer.Dispose();
            }

            Shapes.DrawTmp(Graphics.FromImage(TmpLayer));
            DynamicLayer = TmpLayer;
        }
    }
}
