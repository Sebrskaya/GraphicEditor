using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicEditor
{
    class Painter
    {
        Graphics graphics;
        Pen pen;
        SolidBrush solidBrush;

        public Painter()
        {
            // Создание пера
            pen = new Pen(Color.Black);
            // Создание кисти
            solidBrush = new SolidBrush(Color.White);
        }

        // Настройка холста
        public void SetPort(IntPtr handle)
        {
            graphics = Graphics.FromHwnd(handle);
        }

        public void Clear()
        {
            graphics.Clear(Color.White);
        }

        public void DrawMarker(int x, int y)//отрисовка маркера
        {
            Pen penMarker = new Pen(Color.Black, 1);
            graphics.DrawRectangle(penMarker, x - 3, y - 3, 6, 6);
            SolidBrush solidBrushMarker = new SolidBrush(Color.White);
            graphics.FillRectangle(solidBrushMarker, x - 3 + penMarker.Width / 2, y - 3 + penMarker.Width / 2, 6 - penMarker.Width, 6 - penMarker.Width);
        }

        public void Line(int x1, int y1, int x2, int y2)
        {
            graphics.DrawLine(pen, x1, y1, x2, y2);
        }
        public void Rectangle(int x, int y, int width, int height)
        {
            // Если значения width и height отрицательные,
            // то для правильной отрисовки необходимо их прибавить к паре координат

            // Перемещение в сторону увеличения x и y
            if (width < 0 && height < 0)
            {
                graphics.DrawRectangle(pen, x + width, y + height, Math.Abs(width), Math.Abs(height));
                graphics.FillRectangle(solidBrush, x + width + pen.Width / 2, y + height + pen.Width / 2, Math.Abs(width) - pen.Width, Math.Abs(height) - pen.Width);
                return;
            }

            // Перемещение в сторону увеличения x
            if (width < 0)
            {
                graphics.DrawRectangle(pen, x + width, y, Math.Abs(width), height);
                graphics.FillRectangle(solidBrush, x + width + pen.Width / 2, y + pen.Width / 2, Math.Abs(width) - pen.Width, height - pen.Width);
                return;
            }

            // Перемещение в сторону увеличения y
            if (height < 0)
            {
                graphics.DrawRectangle(pen, x, y + height, width, Math.Abs(height));
                graphics.FillRectangle(solidBrush, x + pen.Width / 2, y + height + pen.Width / 2, width - pen.Width, Math.Abs(height) - pen.Width);
                return;
            }
            graphics.DrawRectangle(pen, x, y, Math.Abs(width), Math.Abs(height));
            graphics.FillRectangle(solidBrush, x + pen.Width / 2, y + pen.Width / 2, width - pen.Width, height - pen.Width);
        }
        public void Ellipse(int x, int y, int width, int height)
        {
            // Если значения width и height отрицательные,
            // то для правильной отрисовки необходимо их прибавить к паре координат

            // Перемещение в сторону увеличения x и y
            if (width < 0 && height < 0)
            {
                graphics.DrawEllipse(pen, x + width, y + height, Math.Abs(width), Math.Abs(height));
                graphics.FillEllipse(solidBrush, x + width + pen.Width / 2, y + height + pen.Width / 2, Math.Abs(width) - pen.Width, Math.Abs(height) - pen.Width);
                return;
            }

            // Перемещение в сторону увеличения x
            if (width < 0)
            {
                graphics.DrawEllipse(pen, x + width, y, Math.Abs(width), height);
                graphics.FillEllipse(solidBrush, x + width + pen.Width / 2, y + pen.Width / 2, Math.Abs(width) - pen.Width, height - pen.Width);
                return;
            }

            // Перемещение в сторону увеличения y
            if (height < 0)
            {
                graphics.DrawEllipse(pen, x, y + height, width, Math.Abs(height));
                graphics.FillEllipse(solidBrush, x + pen.Width / 2, y + height + pen.Width / 2, width - pen.Width, Math.Abs(height) - pen.Width);
                return;
            }
            graphics.DrawEllipse(pen, x, y, Math.Abs(width), Math.Abs(height));
            graphics.FillEllipse(solidBrush, x + pen.Width / 2, y + pen.Width / 2, width - pen.Width, height - pen.Width);
        }

        public Color LineColor
        {
            set
            {
                pen.Color = value;
            }
        }

        public float LineWidht
        {
            set
            {
                pen.Width = value;
            }
        }
        public Color FillColor
        {
            set
            {
                solidBrush.Color = value;
            }
        }

    }
}
