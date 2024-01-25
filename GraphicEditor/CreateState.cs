using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class CreateState : State
    {
        ObjectType ObjectType { get; set; }
        public CreateState(Model model, ObjectType objectType) : base(model)
        {
            ObjectType = objectType;
        }

        public override void MouseDown(int x, int y, StateContainer stateContainer)
        {
            // Начальное создание объекта (можно растянуть до нужного размера)
            model.Creator.ObjectType = ObjectType;
            model.Creator.CreateObject(x, y);
            model.SelectDealer.TrySelect(x, y);
            if (model.SelectDealer.TryGrab(x, y))
            {
                // Переход в состояние DragState
                stateContainer.State = new DragState(model);
            }
        }

        public override void Esc(StateContainer stateContainer)
        {
            stateContainer.State = new EmptyState(model);
        }
    }

}
