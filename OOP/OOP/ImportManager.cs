using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using ShapeContract;

namespace OOP
{
    class ImportManager
    {
        [ImportMany(typeof(Shape))]
        public IEnumerable<Lazy<Shape>> readerExtCollection { get; set; }
    }
}
