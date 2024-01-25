using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    interface IController
    {
        IModel Model { set; }

        IPaint PaintController { get; }

        IAction Action { get; }
    }
}
