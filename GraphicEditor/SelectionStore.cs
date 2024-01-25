using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class SelectionStore : List<Selection>
    {
        public void Release()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Release();
            }
        }
        public void DeleteSelections(List<GraphicObject> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    if (list[i].Equals(this[j].GraphicObject)) Remove(this[j]);
                }
            }
        }
        
        //Выделен ли объект
        public bool IsSelected(GraphicObject graphicObject)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].GraphicObject.Equals(graphicObject))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
