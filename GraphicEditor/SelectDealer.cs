using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class SelectDealer : ISelectDealer
    {
        SelectionStore selectionStore;
        ObjectsStore store;
        Painter painter;
        Factory factory;
        LayersList layersList;

        //в селект дилер через конструктор получили объект сторе
        public SelectDealer(SelectionStore selectionStore, ObjectsStore store, Painter painter, Factory factory, LayersList layersList)
        {
            this.selectionStore = selectionStore;
            this.store = store;
            this.painter = painter;
            this.factory = factory;
            this.layersList = layersList;
        }
        public bool TrySelect(int x, int y)
        {
            //перед выделением все очищаем
            selectionStore.Clear();
            GraphicObject obj = store.GetObjAtPoint(x, y);
            if (obj != null) 
                if(obj.LayerIndex == layersList.ActiveLayerIndex & obj.IsVisible == true) // это доступ к объекту
                {
                    selectionStore.Add(CreateSelection(obj));
                    return true;
                }
            return false;
        }
        //Создаем выделения ищем их тип
        private Selection CreateSelection(GraphicObject obj)
        {
            if (obj is Line)
            {
                return new LineSelection(painter, obj as Line);
            }
            if (obj is Rectangle)
            {
               return new RectangleSelection(painter, obj as Rectangle);
            }
            if (obj is Ellipse)
            {
                return new EllipseSelection(painter, obj as Ellipse);
            }
            if(obj is Group)
            {
                return new GroupSelection(painter, obj as Group);
            }

            return null;
        }

        public bool TryGrab(int x, int y)
        {
            // освобождение selection
            selectionStore.Release();
            for (int i = 0; i < selectionStore.Count; i++)
            {
                if (selectionStore[i].TryGrab(x, y)) return true;

            }
            return false;
        }
        
        public bool TryDrag(int x, int y)
        {
            for (int i = 0; i < selectionStore.Count; i++)
            {
                if (selectionStore[i].TryDrag(x, y)) return true;
            }

            return false;
        }

        public bool TryRelease()
        {
            for (int i = 0; i < selectionStore.Count; i++)
            {
                if (selectionStore[i].Release()) return true;
            }

            return false;
        }

        public void SkipSelection(List<GraphicObject> list)
        {
            selectionStore.DeleteSelections(list);
        }

        public void DeleteSelected()
        {
            List<GraphicObject> list = GetListOfSelectedObjects();
            store.DeleteObjects(list);
            SkipSelection(list);
        }

        private List<GraphicObject> GetListOfSelectedObjects()
        {
            List<GraphicObject> list = new List<GraphicObject>();
            for (int i = 0; i < selectionStore.Count; i++)
            {
                list.Add(selectionStore[i].GraphicObject);
            }

            return list;
        }

        public bool TryAddSelection(int x, int y)
        {
            GraphicObject graphicObject = store.GetObjAtPoint(x, y);
            if (graphicObject == null) return false;
            if (selectionStore.IsSelected(graphicObject)) return false;


            Selection selection = CreateSelection(graphicObject);
            selectionStore.Add(selection);

            return true;
        }

        public void Group()
        {
            // Получение всех выделенных объектов
            List<GraphicObject> list = GetListOfSelectedObjects();
            // Удаление выделений выделенных объектов
            SkipSelection(list);
            // Создание группы
            factory.CreateGroup(list);
            // либо брать всегда последний объект objectStore, либо сделать так,
            // чтобы  CreateObject возвращал создаваемый объект (параметр, передаваемый в CreateSelection)
            Selection groupSelection = CreateSelection(store[store.Count - 1]);
            selectionStore.Add(groupSelection);
        }
        public void Ungroup()
        {
            if (selectionStore.Count > 1) return;
            if (!(selectionStore[0] is GroupSelection)) return;

            // Получение группы
            List<GraphicObject> list = GetListOfSelectedObjects();
            Group group = (Group)list[0];
            // Удаление группы
            store.DeleteObjects(list);
            // Удаление выделения группы 
            selectionStore.Clear();
            // Добавление объектов из группы в хранилище и создание выделений
            for (int i = 0; i < group.GroupObjects.Count; i++)
            {
                GraphicObject graphicObject = group.GroupObjects[i];
                store.Add(graphicObject);
                selectionStore.Add(CreateSelection(graphicObject));
            }
        }
        public bool TryReplace(int x, int y)
        {
            for (int i = 0; i < selectionStore.Count; i++)
            {
                if (!selectionStore[i].TryReplace(x, y)) return false; 
            }
            return true;
        }

    }
}
