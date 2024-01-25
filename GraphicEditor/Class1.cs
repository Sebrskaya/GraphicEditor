using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class Layer
    {
        public int Index { get; set; }
        public string Name { get; set; } 
        public bool Visibility { get; set; } = true;
    }
}
