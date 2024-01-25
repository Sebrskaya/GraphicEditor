using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class EmptyState: State
    {
        public EmptyState(Model model) : base(model) { }

        public override void MouseUp(int x, int y, StateContainer stateContainer)
        {
            if (model.SelectDealer.TrySelect(x, y))
            {
                model.PaintController.Refresh();
                stateContainer.State = new SingleSelectedState(model);
            }
        }
    }
}
