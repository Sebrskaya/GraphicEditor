using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class Marker
    {
        public Marker(int x, int y, int location)
        {
            X = x;
            Y = y;
            this.markerNumber = location;
        }

        // Номер маркера (например, 1 - левый верхний, 2 - правый нижний, 3 - правый верхний, 4 - левый нижний)
        int markerNumber;
        public int MarkerNumber { get => markerNumber; }

        // Координаты края одной из фигуры
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw(Painter painter)
        {
            // Здесь отрисовка маркера
            painter.DrawMarker(X, Y);
        }

        public bool TryGrab(int x, int y)
        {
            if (x >= X - 3 && x <= X + 3 && y >= Y - 3 && y <= Y + 3) return true;

            return false;
        }
    }
}
