using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicEditor
{
    interface IPaint
    {
        void SetPort(IntPtr handle);

        void Refresh();

        void Clear();

        void Line(int x1, int y1, int x2, int y2);

        void Rectangle(int x, int y, int width, int height);

        void Ellipse(int x, int y, int width, int height);

        Color LineColor { set; }

        float LineWidht { set; }

        Color FillColor { set; }
    }
}
