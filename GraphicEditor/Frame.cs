using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor
{
    class Frame
    {
        public delegate void Change();
        public event Change changeNotify;
        // Задание границ фигуры
        public Frame(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public static Frame operator +(Frame frame1, Frame frame2)
        {
            int x1, y1, x2, y2;
            int minXFrame1, minXFrame2, minYFrame1, minYFrame2;
            int maxXFrame1, maxXFrame2, maxYFrame1, maxYFrame2;

            minXFrame1 = Math.Min(frame1.X1, frame1.X2);
            minXFrame2 = Math.Min(frame2.X1, frame2.X2);
            minYFrame1 = Math.Min(frame1.Y1, frame1.Y2);
            minYFrame2 = Math.Min(frame2.Y1, frame2.Y2);

            maxXFrame1 = Math.Max(frame1.X1, frame1.X2);
            maxXFrame2 = Math.Max(frame2.X1, frame2.X2);
            maxYFrame1 = Math.Max(frame1.Y1, frame1.Y2);
            maxYFrame2 = Math.Max(frame2.Y1, frame2.Y2);


            x1 = minXFrame1 <= minXFrame2 ? minXFrame1 : minXFrame2;
            y1 = minYFrame1 <= minYFrame2 ? minYFrame1 : minYFrame2;
            x2 = maxXFrame1 >= maxXFrame2 ? maxXFrame1 : maxXFrame2;
            y2 = maxYFrame1 >= maxYFrame2 ? maxYFrame1 : maxYFrame2;

            return new Frame(x1, y1, x2, y2);
        }

        // Координаты границы фигуры
        int x1, y1, x2, y2;

        public int X1 { get => x1; }

        public int Y1 { get => y1; }

        public int X2 { get => x2; }

        public int Y2 { get => y2; }

        public bool ChangeFrame(Marker marker, int moveX, int moveY)
        {
            try
            {
                switch (marker.MarkerNumber)
                {
                    case 1:
                        x1 = moveX;
                        y1 = moveY;
                        return true;
                    case 4:
                        x1 = moveX;
                        y2 = moveY;
                        return true;
                    case 2:
                        x2 = moveX;
                        y2 = moveY;
                        return true;
                    case 3:
                        x2 = moveX;
                        y1 = moveY;
                        return true;
                    case 0:
                        return false;
                    default:
                        return false;
                }
            }
            finally
            {
                changeNotify?.Invoke();
            }
        }

        public void RecalcCoords(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;

            changeNotify?.Invoke();
        }

        public void ChangeFrameByReplacingObject(int[] distance, int x, int y)
        {
            x1 = x - distance[0];
            y1 = y - distance[1];
            x2 = x + distance[2];
            y2 = y + distance[3];

            changeNotify?.Invoke();
        }
    }
}

