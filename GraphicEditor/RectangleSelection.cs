using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class RectangleSelection : Selection
    {
        Rectangle Rectangle { get; set; }
        public RectangleSelection(Painter painter, Rectangle obj) : base(obj)
        {
            Rectangle = obj;
            CreateMarkers();
        }
        protected override void CreateMarkers()
        {
            Frame frame = Rectangle.Frame;

            Marker marker = new Marker(frame.X1, frame.Y1, 1);
            markers.Add(marker);

            Marker marker2 = new Marker(frame.X2, frame.Y2, 2);
            markers.Add(marker2);

            Marker marker3 = new Marker(frame.X2, frame.Y1, 3);
            markers.Add(marker3);

            Marker marker4 = new Marker(frame.X1, frame.Y2, 4);
            markers.Add(marker4);
        }

        protected override bool RefreshMarkerCoordinates()
        {
            for (int i = 0; i < markers.Count; i++)
            {
                switch (markers[i].MarkerNumber)
                {
                    case 1:
                        markers[i].X = Rectangle.Frame.X1;
                        markers[i].Y = Rectangle.Frame.Y1;
                        break;
                    case 2:
                        markers[i].X = Rectangle.Frame.X2;
                        markers[i].Y = Rectangle.Frame.Y2;
                        break;
                    case 3:
                        markers[i].X = Rectangle.Frame.X2;
                        markers[i].Y = Rectangle.Frame.Y1;
                        break;
                    case 4:
                        markers[i].X = Rectangle.Frame.X1;
                        markers[i].Y = Rectangle.Frame.Y2;
                        break;
                    default:
                        return false;
                }
            }

            return true;
        }

    }
}
