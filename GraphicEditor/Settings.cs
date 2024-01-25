using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class Settings : ISettings
    {
        IModel Model { get; set; }
        IObjectStyleSettings objectStyleSettings;
        public Settings(IModel model, IObjectStyleSettings objectStyleSettings)
        {
            Model = model;
            this.objectStyleSettings = objectStyleSettings;
        }
        public ObjectType ObjectType { get; set; }

        public IObjectStyleSettings ObjectStyleSettings { get => objectStyleSettings; }

        public void SetObjectType()
        {
            Model.Creator.ObjectType = ObjectType;
        }

        public void SetObjectStyleSettings()
        {
            Model.FactorySettings.PenSettings.LineColor = objectStyleSettings.PenSettings.LineColor;
            Model.FactorySettings.PenSettings.LineWidth = objectStyleSettings.PenSettings.LineWidth;
            Model.FactorySettings.BrushSettings.BrushColor = objectStyleSettings.BrushSettings.BrushColor;
        }
    }
}
