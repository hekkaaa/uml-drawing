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
        public Color PenColor { get; set; }
        public string CompName { get; set; }
        public float PenWidth { get; set; }
        public PointF Location { get; set; }
        public string[] Text = new string[3];
        public Color Color { get; set; }
        public Font[] Font = new Font[3];
        public RectangleF[] Rectangles = new RectangleF[3];
        public RectangleF[] TextRectangles = new RectangleF[3];
        public LiveDataElem From { get; set; }
        public LiveDataElem To { get; set; }
        public Arrows ArrowType { get; set; }
        public float LedgePositionX { get; set; }
    }
}
