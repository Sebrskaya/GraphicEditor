using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    abstract class State
    {
        protected Model model;
        //так как только сет, то опять прописываем реализацию
        public Model Model { set { model = value; } }
        //реализация паттерна состояний
        public virtual void MouseUp(int x, int y, StateContainer stateContainer) { }
        public virtual void MouseDown(int x, int y, StateContainer stateContainer) { }
        public virtual void MouseMove(int x, int y, StateContainer stateContainer) { }

        public State(Model model)
        {
            this.Model = model;
        }
        public void StartCreate(ObjectType objectType, StateContainer stateContainer)
        {
            model.SelectDealer.TryRelease(); // надо ли?
            stateContainer.State = new CreateState(model, objectType); // удалить из Settings свойство ObjectType
        }
        public virtual void Esc(StateContainer stateContainer) { }
        public virtual void Del(StateContainer stateContainer) { }

        public virtual void ShiftMouseUp(int x, int y, StateContainer stateContainer) { }
        public virtual void Group(StateContainer stateContainer) { }
        public virtual void Ungroup(StateContainer stateContainer) { }
        
        public void AddLayer(StateContainer stateContainer) 
        {
            model.LayersList.AddLayer();
        }
        public void DeleteLayer(StateContainer stateContainer)
        {
            model.LayersList.DeleteLayer();
        }
        public void UpLayer(StateContainer stateContainer)
        {
            model.LayersList.MoveLayerUp();
        }
        public void DownLayer(StateContainer stateContainer)
        {
            model.LayersList.MoveLayerDown();
        }
        public void VisibilityOff(StateContainer stateContainer)
        {
            model.LayersList.LayerVisibilityOff();
        }
        public void VisibilityOn(StateContainer stateContainer)
        {
            model.LayersList.LayerVisibilityOn();
        }
    }
}
