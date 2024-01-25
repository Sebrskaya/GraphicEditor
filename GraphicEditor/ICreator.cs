using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{

    enum ObjectType
    {
        Line,
        Rectangle,
        Ellipse
    }

    interface ICreator
    {
        ObjectType ObjectType { get; set; }

        void CreateObject(int x, int y);
    }

}
