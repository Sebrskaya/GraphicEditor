using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class Action: IAction
    {
        StateContainer stateContainer;

        public Action(StateContainer stateContainer)
        {
            this.stateContainer = stateContainer;
        }

        public void MouseDown(int x, int y)
        {
            //метод проверки активного слоя
                //return;
            stateContainer.MouseDown(x, y);
        }

        public void MouseUp(int x, int y)
        {
            stateContainer.MouseUp(x, y);
        }

        public void MouseMove(int x, int y)
        {
            stateContainer.MouseMove(x, y);
        }

        public void StartCreate(ObjectType objectType)
        {
            stateContainer.StartCreate(objectType);
        }

        public void Esc()
        {
            stateContainer.Esc();
        }

        public void Del()
        {
            stateContainer.Del();
        }

        public void ShiftMouseUp(int x, int y)
        {
            stateContainer.ShiftMouseUp(x, y);
        }

        public void Group()
        {
            stateContainer.Group();
        }

        public void Ungroup()
        {
            stateContainer.Ungroup();
        }

        public void AddLayer()
        {
            stateContainer.AddLayer();
        }

        public void DeleteLayer()
        {
            stateContainer.DeleteLayer();
        }

        public void UpLayer()
        {
            stateContainer.UpLayer();
        }

        public void DownLayer()
        {
            stateContainer.DownLayer();
        }

        public void VisibilityOff()
        {
            stateContainer.VisibilityOff();
        }

        public void VisibilityOn()
        {
            stateContainer.VisibilityOn();
        }



    }
}
