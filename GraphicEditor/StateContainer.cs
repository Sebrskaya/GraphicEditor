using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditor
{
    class StateContainer
    {
        public State State { get; set; }//хранение состояния
        public StateContainer(State state)
        {
            State = state;
        }
        //в стейте храним активное сосоотояние, в зависимости от него метода даун мув ап буду делать вещи, прописанные в будущих 
        //стэйтов
        //this указывает здесь на оббъект самого класса
        public void MouseUp(int x, int y) { State.MouseUp(x, y, this); }
        public void MouseDown(int x, int y) { State.MouseDown(x, y, this); }
        public void MouseMove(int x, int y) { State.MouseMove(x, y, this); }

        public void StartCreate(ObjectType objectType)
        {
            State.StartCreate(objectType, this);
        }

        public void Esc()
        {
            State.Esc(this);
        }

        public void Del()
        {
            State.Del(this);
        }

        public void ShiftMouseUp(int x, int y)
        {
            State.ShiftMouseUp(x, y, this);
        }

        public void Group()
        {
            State.Group(this);
        }

        public void Ungroup()
        {
            State.Ungroup(this);
        }

        public void AddLayer()
        {
            State.AddLayer(this);
            
        }

        public void DeleteLayer()
        {
            State.DeleteLayer(this);

        }

        public void UpLayer()
        {
            State.UpLayer(this);

        }

        public void DownLayer()
        {
            State.DownLayer(this);
        }

        public void VisibilityOff()
        {
            State.VisibilityOff(this);
        }

        public void VisibilityOn()
        {
            State.VisibilityOn(this);
        }
    }
}
