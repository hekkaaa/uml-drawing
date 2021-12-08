using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace UML_Database_Library.BlackBox
{
    public enum Arrows
    {
        AssociationArrow,
        AggregationArrow,
        AddictionArrow,
        CompositionArrow,
        InheritanceArrow,
        RealizationArrow
    }
    [Serializable]
    public class LiveDataElem
    {
        // Элемент в диаграмме
        public int _id { get; set; }
        public Color _penColor { get; set; }
        public string CompName { get; set; }
        public float _penWidth { get; set; }

        //public GraphicsPath SerializablePath { get; set; }
        public PointF Location { get; set; }
        public string[] Text = new string[3];
        public Color Color { get; set; }

        public Font[] Font = new Font[3];
        //прямоугольник, в котором расположен текст
        public RectangleF TextRect { get; set; }
        public SerializableGraphicPath SerializablePath { get; set; } = new SerializableGraphicPath();
        public RectangleF Bounds { get; set; }
        public Rectangle[] TextBounds { get; set; } = new Rectangle[3];
        public RectangleF[] Rectangles = new RectangleF[3];
        public RectangleF[] TextRectangles = new RectangleF[3];
        public LiveDataElem From { get; set; }
        public LiveDataElem To { get; set; }
        public Arrows ArrowType { get; set; }
        public float LedgePositionX { get; set; }
    }

    [Serializable]
    public class SerializableGraphicPath : ISerializable
    {
        public GraphicsPath Value = new GraphicsPath();

        public SerializableGraphicPath()
        {
        }

        private SerializableGraphicPath(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount > 0)
            {
                PointF[] points = (PointF[])info.GetValue("point", typeof(PointF[]));
                byte[] types = (byte[])info.GetValue("type", typeof(byte[]));
                Value = new GraphicsPath(points, types);
            }
            else
                Value = new GraphicsPath();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (Value.PointCount > 0)
            {
                info.AddValue("point", Value.PathPoints);
                info.AddValue("type", Value.PathTypes);
            }
        }
    }
}
