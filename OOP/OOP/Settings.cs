using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Settings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Color BackGround { get; set; }

        public string ModuleExtension { get; set; }
        public string ImageExtension { get; set; }
        public string InstrumentExtension { get; set; }

        public string ModulePath { get; set; }
        public string ImagePath { get; set; }
        public string InstrumentPath { get; set; }
    }
}
