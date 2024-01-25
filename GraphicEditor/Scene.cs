using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class Scene
    {
        Painter painter;
        ObjectsStore objectsStrore;
        SelectionStore selectionStore;

        public Scene(ObjectsStore objectsStrore,  Painter painter, SelectionStore selectionStore)
        {
            this.painter = painter;
            this.objectsStrore = objectsStrore;
            this.selectionStore = selectionStore;
        }

        public void Refresh()
        {
            painter.Clear();
            for (int i = 0; i < objectsStrore.Count; i++)
            {
                if (objectsStrore[i].IsVisible == true)
                    objectsStrore[i].Draw(painter);
            }
            // Отрисовка выделений(маркеров)
            for (int i = 0; i < selectionStore.Count; i++)
            {
                if (selectionStore[i].GraphicObject.IsVisible == true)
                    selectionStore[i].Draw(painter);
            }

        }
    }
}
