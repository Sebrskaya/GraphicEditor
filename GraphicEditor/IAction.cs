using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    interface IAction //отловка действий
    {
        // Начальное создание объекта
        void StartCreate(ObjectType objectType);

        // Выход
        void Esc();

        // Удаление
        void Del();

        // Выделение фигур 
        void ShiftMouseUp(int x, int y);

        // Группировка объектов
        void Group();

        // Разгруппировка объектов
        void Ungroup();

        void MouseUp(int x, int y);
        void MouseDown(int x, int y);
        void MouseMove(int x, int y);
        void AddLayer();
        void DeleteLayer();
        void UpLayer();
        void DownLayer();
        void VisibilityOff();
        void VisibilityOn();

    }
}
