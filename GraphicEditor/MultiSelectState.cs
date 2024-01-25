using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class MultiSelectState:State
    {
        public MultiSelectState(Model model) : base(model) { }

        public override void ShiftMouseUp(int x, int y, StateContainer stateContainer)
        {
            if (model.SelectDealer.TryAddSelection(x, y)) model.PaintController.Refresh();
        }

        public override void Esc(StateContainer stateContainer)
        {
            stateContainer.State = new EmptyState(model);
        }

        public override void Del(StateContainer stateContainer)
        {
            model.SelectDealer.DeleteSelected();
            model.PaintController.Refresh();
            stateContainer.State = new EmptyState(model);
        }
        public override void Group(StateContainer stateContainer)
        {
            model.SelectDealer.Group();
            model.PaintController.Refresh();
            stateContainer.State = new SingleSelectedState(model);
        }
        public override void MouseMove(int x, int y, StateContainer stateContainer)
        {
            if (model.SelectDealer.TryReplace(x, y))
            {
                model.PaintController.Refresh();
            }
        }
    }
}
