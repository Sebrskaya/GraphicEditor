using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    interface IObjectStyleSettings
    {
        IPenSettings PenSettings { get; }

        IBrushSettings BrushSettings { get; }
    }

}
