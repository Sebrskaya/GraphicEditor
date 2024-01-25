using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicEditor
{
    abstract class SetOfProps
    {
        public abstract void Apply(Painter painter);
    }

    class PropertiesList : List<SetOfProps>
    {
        public void Apply(Painter painter)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Apply(painter);
            }
        }
    }

    class LineSetOfProperties : SetOfProps, IPenSettings
    {
        public LineSetOfProperties(Color color, float width)
        {
            LineColor = color;
            LineWidth = width;
        }

        public Color LineColor { get; set; }
        public float LineWidth { get; set; }

        public override void Apply(Painter painter)
        {
            painter.LineColor = LineColor;
            painter.LineWidht = LineWidth;
        }
        public LineSetOfProperties Clone()
        {
            return new LineSetOfProperties(LineColor, LineWidth);
        }
    }

    class FillSetOfProperties : SetOfProps, IBrushSettings
    {
        public FillSetOfProperties(Color color)
        {
            BrushColor = color;
        }

        public Color BrushColor { get; set; }

        public override void Apply(Painter painter)
        {
            painter.FillColor = BrushColor;
        }
        public FillSetOfProperties Clone()
        {
            return new FillSetOfProperties(BrushColor);
        }
    }
}
