using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class ObjectsStore: List<GraphicObject>
    {
        public ObjectsStore() 
        {
            
        }
        public GraphicObject GetObjAtPoint(int x, int y)//ищет объекты 
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this[i].InBody(x, y))
                {
                    return this[i];
                }
            }
            return null;
        }
        public void DeleteObjects(List<GraphicObject> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    if (list[i].Equals(this[j])) Remove(this[j]);
                }
            }
        }
    }
}
