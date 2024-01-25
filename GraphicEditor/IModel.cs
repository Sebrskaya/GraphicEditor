using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    interface IModel
    {
        ICreator Creator { get; }
        IPaint PaintController { get; }
        ISelectDealer SelectDealer { get; }
        IObjectStyleSettings FactorySettings { get; }
        LayersList LayersList { get; }

    }
}
