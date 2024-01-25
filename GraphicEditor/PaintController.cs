using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicEditor
{
    class PaintController: IPaint
    {
        Painter painter;
        Scene scene;

        public PaintController(Scene scene, Painter painter)
        {
            this.scene = scene;
            this.painter = painter;
        }

        public void SetPort(IntPtr handle)
        {
            painter.SetPort(handle);
        }

        public void Refresh()
        {
            scene.Refresh();
        }

        public void Clear()
        {
            painter.Clear();
        }

        public void Line(int x1, int y1, int x2, int y2)
        {
            painter.Line(x1, y1, x2, y2);
        }

        public void Rectangle(int x, int y, int width, int height)
        {
            painter.Rectangle(x, y, width, height);
        }

        public void Ellipse(int x, int y, int width, int height)
        {
            painter.Ellipse(x, y, width, height);
        }

        public Color LineColor
        {
            set
            {
                painter.LineColor = value;
            }
        }

        public float LineWidht
        {
            set
            {
                painter.LineWidht = value;
            }
        }

        public Color FillColor
        {
            set
            {
                painter.FillColor = value;
            }
        }
    }
}
