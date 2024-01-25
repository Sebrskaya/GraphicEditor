using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicEditor
{
    class Factory: ICreator, IObjectStyleSettings
    {
        LineSetOfProperties lineSetOfProperties;
        FillSetOfProperties fillSetOfProperties;
        ObjectsStore objectsStore;
        LayersList layersList;

        public Factory(ObjectsStore objectsStore, LayersList layersList)
        {
            this.objectsStore = objectsStore;
            lineSetOfProperties = new LineSetOfProperties(Color.Black, 1);
            fillSetOfProperties = new FillSetOfProperties(Color.Black);
            this.layersList = layersList;
        }

        public IPenSettings PenSettings { get => lineSetOfProperties; }
        public IBrushSettings BrushSettings { get => fillSetOfProperties; }

        public ObjectType ObjectType { get; set; }

        public void CreateGroup(List<GraphicObject> list)
        {
            objectsStore.DeleteObjects(list);
            Group group = new Group(list);
            objectsStore.Add(group);
        }

        public void CreateObject(int x, int y)
        {
            switch (ObjectType)
            {
                case ObjectType.Line:
                    Frame frame = new Frame(x, y, x, y);
                    PropertiesList props = new PropertiesList();
                    props.Add(lineSetOfProperties.Clone());
                    Line line = new Line(frame, props);
                    line.LayerIndex = layersList.ActiveLayerIndex;
                    objectsStore.Insert(GetIndexOfObjectsLayer(line.LayerIndex), line);//Вставка к слою
                    break;
                
                case ObjectType.Rectangle:
                    frame = new Frame(x, y, x, y);
                    props = new PropertiesList();
                    props.Add(lineSetOfProperties.Clone());
                    props.Add(fillSetOfProperties.Clone());
                    Rectangle rectangle = new Rectangle(frame, props);
                    rectangle.LayerIndex = layersList.ActiveLayerIndex;
                    objectsStore.Insert(GetIndexOfObjectsLayer(rectangle.LayerIndex), rectangle);
                    break;
                
                case ObjectType.Ellipse:
                    frame = new Frame(x, y, x, y);
                    props = new PropertiesList();
                    props.Add(lineSetOfProperties.Clone());
                    props.Add(fillSetOfProperties.Clone());
                    Ellipse ellipse = new Ellipse(frame, props);
                    ellipse.LayerIndex = layersList.ActiveLayerIndex;
                    objectsStore.Insert(GetIndexOfObjectsLayer(ellipse.LayerIndex), ellipse);
                    break;
            }
                    
        }

        public int GetIndexOfObjectsLayer(int layerIndex)
        {
            if (objectsStore.Count == 0)
            {
                return 0;
            }
            for (int i = objectsStore.Count - 1; i >= 0; i--)
            {
                if (layerIndex == objectsStore[i].LayerIndex)
                {
                    return i + 1;
                }
            }

            return objectsStore.Count;
        }

    }
}
