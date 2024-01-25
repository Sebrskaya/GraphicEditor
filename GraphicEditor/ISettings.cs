using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    interface ISettings
    {
        ObjectType ObjectType { get; set; }

        IObjectStyleSettings ObjectStyleSettings { get; }

        void SetObjectType();
        void SetObjectStyleSettings();
    }
}
