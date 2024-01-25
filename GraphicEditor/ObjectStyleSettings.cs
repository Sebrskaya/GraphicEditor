using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class ObjectStyleSettings : IObjectStyleSettings
    {
        IModel Model { get; set; }
        public ObjectStyleSettings(IModel model)
        {
            Model = model;
        }
        public IPenSettings PenSettings { get => Model.FactorySettings.PenSettings; }

        public IBrushSettings BrushSettings { get => Model.FactorySettings.BrushSettings; }
    }
}
