using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class GroupSelection : Selection
    {
        Group Group { get; set; }
        public GroupSelection(Painter painter, Group group) : base(group)
        {
            Group = group;
            CreateMarkers();
        }

        protected override void CreateMarkers()
        {
            Frame frame = Group.Frame;

            Marker marker = new Marker(frame.X1, frame.Y1, 1);
            markers.Add(marker);

            Marker marker2 = new Marker(frame.X1, frame.Y2, 4);
            markers.Add(marker2);

            Marker marker3 = new Marker(frame.X2, frame.Y2, 2);
            markers.Add(marker3);

            Marker marker4 = new Marker(frame.X2, frame.Y1, 3);
            markers.Add(marker4);
        }

        protected override bool RefreshMarkerCoordinates()
        {
            for (int i = 0; i < markers.Count; i++)
            {
                switch (markers[i].MarkerNumber)
                {
                    case 1:
                        markers[i].X = Group.Frame.X1;
                        markers[i].Y = Group.Frame.Y1;
                        break;
                    case 2:
                        markers[i].X = Group.Frame.X2;
                        markers[i].Y = Group.Frame.Y2;
                        break;
                    case 3:
                        markers[i].X = Group.Frame.X2;
                        markers[i].Y = Group.Frame.Y1;
                        break;
                    case 4:
                        markers[i].X = Group.Frame.X1;
                        markers[i].Y = Group.Frame.Y2;
                        break;
                    default:
                        return false;
                }
            }

            return true;
        }
    }

}
