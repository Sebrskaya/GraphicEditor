using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicEditor
{
    abstract class GraphicObject
    {
        Frame frame;
        public GraphicObject(Frame frame)
        {
            this.frame = frame;
        }

        public abstract void Draw(Painter painter);

        public int LayerIndex { get; set; }

        public bool IsVisible { get; set; } = true;

        public Frame Frame
        {
            get
            {
                return frame;
            }
        }

        //

        public bool InBody(int x, int y)
        {
            if (x >= Math.Min(Frame.X1, Frame.X2) && x <= Math.Max(Frame.X1, Frame.X2)
                 && y >= Math.Min(Frame.Y1, Frame.Y2) && y <= Math.Max(Frame.Y1, Frame.Y2))
            {
                return true;
            }
            return false;
        }
    }

    abstract class Figure : GraphicObject
    {
        PropertiesList propertiesList;
        public Figure(Frame frame, PropertiesList propertiesList) : base(frame)
        {
            this.propertiesList = propertiesList;
        }

        public override void Draw(Painter painter)
        {
            propertiesList.Apply(painter);
            DrawGeometry(painter);
        }
        public abstract void DrawGeometry(Painter painter);
    }

    class Group : GraphicObject
    {
        List<GraphicObject> listOfGraphicObject = new List<GraphicObject>();
        List<float[]> listOfCoefficient = new List<float[]>();

        public List<GraphicObject> GroupObjects { get => listOfGraphicObject; }

        public List<float[]> CoordinateDifference { get => listOfCoefficient; }

        private void WhenFrameChanged()
        {
            ItemsFrameRecalc();
        }
        public Group(List<GraphicObject> listOfGraphicObject) : base(SetFrame(listOfGraphicObject))
        {
            for (int i = 0; i < listOfGraphicObject.Count; i++)
            {
                this.listOfGraphicObject.Add(listOfGraphicObject[i]);
            }

            CalculateCoordinates();

            Frame.changeNotify += WhenFrameChanged;
        }

        public override void Draw(Painter painter)
        {
            for (int i = 0; i < listOfGraphicObject.Count; i++)
            {
                listOfGraphicObject[i].Draw(painter);
            }
        }

        static Frame SetFrame(List<GraphicObject> listOfGraphicObject)
        {
            Frame frame = listOfGraphicObject[0].Frame;

            for (int i = 1; i < listOfGraphicObject.Count; i++)
            {
                frame += listOfGraphicObject[i].Frame;
            }

            return frame;
        }

        private void ItemsFrameRecalc()
        {
            for (int i = 0; i < GroupObjects.Count; i++)
            {
                Frame objectFrame = GroupObjects[i].Frame;

                int x1 = (int)(Frame.X1 + listOfCoefficient[i][0] * (Frame.X2 - Frame.X1));
                int y1 = (int)(Frame.Y1 + listOfCoefficient[i][1] * (Frame.Y2 - Frame.Y1));
                int x2 = (int)(Frame.X1 + listOfCoefficient[i][2] * (Frame.X2 - Frame.X1));
                int y2 = (int)(Frame.Y1 + listOfCoefficient[i][3] * (Frame.Y2 - Frame.Y1));

                objectFrame.RecalcCoords(x1, y1, x2, y2);
            }
        }

        public void CalculateCoordinates()
        {
            for (int i = 0; i < GroupObjects.Count; i++)
            {
                // относительная координата x1
                float x1 = (float)(GroupObjects[i].Frame.X1 - Frame.X1) / (float)(Frame.X2 - Frame.X1);
                // относительная координата y1
                float y1 = (float)(GroupObjects[i].Frame.Y1 - Frame.Y1) / (float)(Frame.Y2 - Frame.Y1);
                // относительная координата x2
                float x2 = (float)(GroupObjects[i].Frame.X2 - Frame.X1) / (float)(Frame.X2 - Frame.X1);
                // относительная координата y2
                float y2 = (float)(GroupObjects[i].Frame.Y2 - Frame.Y1) / (float)(Frame.Y2 - Frame.Y1);

                float[] temp = new float[4];
                temp[0] = x1;
                temp[1] = y1;
                temp[2] = x2;
                temp[3] = y2;

                listOfCoefficient.Add(temp);
            }
        }
    }


    class Line : Figure
    {
        public Line(Frame frame, PropertiesList propertiesList) : base(frame, propertiesList) { }
        public override void DrawGeometry(Painter painter)
        {
            painter.Line(Frame.X1, Frame.Y1, Frame.X2, Frame.Y2);
        }
    }

    class Ellipse : Figure
    {
        public Ellipse(Frame frame, PropertiesList propertiesList) : base(frame, propertiesList) { }
        public override void DrawGeometry(Painter painter)
        {
            painter.Ellipse(Frame.X1, Frame.Y1, Frame.X2 - Frame.X1, Frame.Y2 - Frame.Y1);
        }
    }

    class Rectangle : Figure
    {
        public Rectangle(Frame frame, PropertiesList propertiesList) : base(frame, propertiesList) { }
        public override void DrawGeometry(Painter painter)
        {
            painter.Rectangle(Frame.X1, Frame.Y1, Frame.X2 - Frame.X1, Frame.Y2 - Frame.Y1);
        }
    }
}
