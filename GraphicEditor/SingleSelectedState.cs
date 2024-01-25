using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class SingleSelectedState: State
    {
        public SingleSelectedState(Model model): base(model) { }

        public override void Esc(StateContainer stateContainer)
        {
            model.SelectDealer.TryRelease();
            model.PaintController.Refresh();
            stateContainer.State = new EmptyState(model);
        }

        public override void Del(StateContainer stateContainer)
        {
            model.SelectDealer.DeleteSelected();
            model.PaintController.Refresh();
            stateContainer.State = new EmptyState(model);
        }
        public override void MouseUp(int x, int y, StateContainer stateContainer)
        {
            if (model.SelectDealer.TrySelect(x, y))
            {
                model.PaintController.Refresh();
            }
        }

        public override void MouseMove(int x, int y, StateContainer stateContainer)
        {
            if (model.SelectDealer.TryReplace(x, y))
            {
                model.PaintController.Refresh();
            }
        }

        public override void MouseDown(int x, int y, StateContainer stateContainer)
        {
            if (model.SelectDealer.TryGrab(x, y))
            {
                stateContainer.State = new DragState(model);
            }
        }

        public override void ShiftMouseUp(int x, int y, StateContainer stateContainer)
        {
            model.SelectDealer.TryAddSelection(x, y);
            //// по сути должны отрисовываться только маркеры, но это пока что не работает
            model.PaintController.Refresh();
            stateContainer.State = new MultiSelectState(model);
        }

        public override void Ungroup(StateContainer stateContainer)
        {
            model.SelectDealer.Ungroup();
            model.PaintController.Refresh();
            stateContainer.State = new MultiSelectState(model);
        }

    }
}
