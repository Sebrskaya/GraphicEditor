using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    interface ISelectDealer
    {
        void Group();
        void Ungroup();
        bool TrySelect(int x, int y);
        bool TryGrab(int x, int y);
        bool TryDrag(int x, int y);
        bool TryRelease();
        void DeleteSelected();
        bool TryAddSelection(int x, int y);
        bool TryReplace(int x, int y);
    }
}
