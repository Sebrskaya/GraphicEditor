using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    enum GrabState
    {
        NotGrabed,
        Marker,
        Body
    }

    abstract class Selection
    {
        GraphicObject graphicObject;
        GrabState grabState;
        protected List<Marker> markers;
        protected Marker activeMarker;
        // Расстояние от курсора до координат фигуры
        int[] distance;
        public Selection(GraphicObject graphicObject)
        {
            this.graphicObject = graphicObject;
            markers = new List<Marker>();
            grabState = GrabState.NotGrabed;
        }

        public GraphicObject GraphicObject { get => graphicObject; }
        public int[] Distance { set => distance = value; }

        // Создание маркеров
        protected abstract void CreateMarkers();

        // Отрисовка маркеров 
        public void Draw(Painter painter)
        {
            for (int i = 0; i < markers.Count; i++)
            {
                markers[i].Draw(painter);
            }
        }

        // Переопределение координат маркеров
        protected abstract bool RefreshMarkerCoordinates();

        // Попытка тянуть за маркер
        public bool TryGrab(int x, int y)
        {
            for (int i = 0; i < markers.Count; i++)
            {
                if (markers[i].TryGrab(x, y))
                {
                    grabState = GrabState.Marker;
                    activeMarker = markers[i];
                    return true;
                }
            }
            return false;
        }

        // Попытка растянуть объект
        public bool TryDrag(int x, int y)
        {
            return graphicObject.Frame.ChangeFrame(activeMarker, x, y)
                && RefreshMarkerCoordinates();
        }

        public bool Release()
        {
            if (grabState != GrabState.NotGrabed)
            {
                grabState = GrabState.NotGrabed;
                return true;
            }

            return false;
        }

        // Попытка переместить объект
        public bool TryReplace(int x, int y)
        {
            if (distance == null)
            {
                CalculateDistanceFromCursor(x, y);
            }

            graphicObject.Frame.ChangeFrameByReplacingObject(distance, x, y);

            if (RefreshMarkerCoordinates())
            {
                return true;
            }

            return false;
        }

        // Вычисление расстояния от курсора до координат фигуры
        private void CalculateDistanceFromCursor(int x, int y)
        {
            int[] temp = new int[4];

            temp[0] = x - graphicObject.Frame.X1;
            temp[1] = y - graphicObject.Frame.Y1;
            temp[2] = graphicObject.Frame.X2 - x;
            temp[3] = graphicObject.Frame.Y2 - y;

            distance = temp;
        }
    }
}
