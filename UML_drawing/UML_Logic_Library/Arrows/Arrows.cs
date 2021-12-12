using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using UML_Logic_Library.AdditionalClasses;
using UML_Logic_Library.Markers;
using UML_Logic_Library.StructuralEntities;

namespace UML_Logic_Library.Arrows
{
    [Serializable]
    public enum ArrowsTypes
    {
        AssociationArrow,
        AggregationArrow,
        AddictionArrow,
        CompositionArrow,
        InheritanceArrow,
        RealizationArrow
    }

    public class Arrows : Component
    {
        public Component From;
        public Component To;
        public ArrowsTypes TypesType;

        private PointF[] _points;
        internal float LedgePositionX = -1;


        public Arrows(ArrowsTypes arrowTypesType)
        {
            TypesType = arrowTypesType;
        }

        public override IEnumerable<Marker> GetMarkers(Handler components)
        {
            RecalcPath();
            EndLineMarker m1 = new EndLineMarker(components, 0);
            m1.TargetComponent = this;
            yield return m1;

            EndLineMarker m2 = new EndLineMarker(components, 1);
            m2.TargetComponent = this;
            yield return m2;

            LedgeMarker m3 = new LedgeMarker();
            m3.TargetComponent = this;
            m3.UpdateLocation();
            yield return m3;
        }

        public override bool PointIsInside(PointF p)
        {
            if (From == null || To == null)
                return false;

            RecalcPath();
            return Path.IsOutlineVisible(p, Pen);
        }

        private void SetPen(ArrowsTypes arrowTypesType)
        {
            switch (arrowTypesType)
            {
                case ArrowsTypes.AddictionArrow:
                    Pen p = new Pen(PenColor, PenWidth);
                    p.CustomEndCap = new AdjustableArrowCap(13, 15, false);
                    p.DashStyle = DashStyle.Dash;
                    p.DashPattern = new float[] {2, 3};
                    Pen = p;
                    break;
                case ArrowsTypes.AssociationArrow:
                    Pen p1 = new Pen(PenColor, PenWidth);
                    p1.CustomEndCap = new AdjustableArrowCap(13, 15, false);
                    Pen = p1;
                    break;
                case ArrowsTypes.AggregationArrow:
                    Pen p2 = new Pen(PenColor, PenWidth);
                    GraphicsPath hPath = new GraphicsPath();
                    hPath.AddLine(new Point(0, 26), new Point(8, 13));
                    hPath.AddLine(new Point(8, 13), new Point(0, 0));
                    hPath.AddLine(new Point(0, 0), new Point(-8, 13));
                    hPath.AddLine(new Point(-8, 13), new Point(0, 26));
                    CustomLineCap diamondCap = new CustomLineCap(null, hPath);
                    p2.CustomEndCap = diamondCap;
                    Pen = p2;
                    break;
                case ArrowsTypes.CompositionArrow:
                    Pen p3 = new Pen(PenColor, PenWidth);
                    GraphicsPath dFCap = new GraphicsPath();
                    dFCap.AddLines(new PointF[]
                        {
                            new Point(0, 0),
                            new Point(-4, -6),
                            new Point(-4, -6),
                            new Point(0, -12),
                            new Point(0, -12),
                            new Point(4, -6),
                            new Point(4, -6),
                            new Point(0, 0)
                        }
                    );
                    CustomLineCap diamondFillCap = new CustomLineCap(dFCap, null);
                    p3.CustomEndCap = diamondFillCap;
                    Pen = p3;
                    break;
                case ArrowsTypes.InheritanceArrow:
                    Pen p4 = new Pen(PenColor, PenWidth);
                    GraphicsPath tCap = new GraphicsPath();
                    tCap.AddLine(new PointF(0, 0), new PointF(8, 0));
                    tCap.AddLine(new PointF(8, 0), new PointF(0, 13));
                    tCap.AddLine(new PointF(0, 13), new PointF(-8, 0));
                    tCap.AddLine(new PointF(-8, 0), new PointF(0, 0));
                    CustomLineCap triangleCap = new CustomLineCap(null, tCap);
                    p4.CustomEndCap = triangleCap;
                    Pen = p4;
                    break;
                case ArrowsTypes.RealizationArrow:
                    Pen p5 = new Pen(PenColor, PenWidth);
                    GraphicsPath tFCap = new GraphicsPath();
                    tFCap.AddLine(new PointF(0, 0), new PointF(8, 0));
                    tFCap.AddLine(new PointF(8, 0), new PointF(0, 13));
                    tFCap.AddLine(new PointF(0, 13), new PointF(-8, 0));
                    tFCap.AddLine(new PointF(-8, 0), new PointF(0, 0));
                    CustomLineCap triangleRealizCap = new CustomLineCap(null, tFCap);
                    p5.CustomEndCap = triangleRealizCap;
                    p5.DashStyle = DashStyle.Dash;
                    p5.DashPattern = new float[] {2, 3};
                    Pen = p5;
                    break;
            }
        }

        public override void Draw(Graphics gr)
        {
            if (From == null || To == null)
                return;

            RecalcPath();
            SetPen(TypesType);
            gr.DrawPath(Pen, Path);
        }

        private void RecalcPath()
        {
            _points = null;

            var from = From as SimpleRectangle;
            var to = To as SimpleRectangle;
            if (LedgePositionX < 0)
                LedgePositionX = (from.Location.X + from.Size.Width / 2 + to.Location.X) / 2;

            PointF locationRectangle;

            var size = TypesType switch
            {
                ArrowsTypes.InheritanceArrow or ArrowsTypes.RealizationArrow => 13,
                ArrowsTypes.AggregationArrow => 26,
                _ => 0
            };

            if (to is RectangleComponent || to is RectangleOneField || to is RectangleTwoFields)
            {
                if (to.Location.X > from.Location.X && LedgePositionX < to.Location.X ||
                    to.Location.X < from.Location.X && LedgePositionX < to.Location.X)
                    locationRectangle = new PointF(to.Location.X - size, to.Location.Y + to.Size.Height / 2 + 10);
                else
                    locationRectangle = new PointF(to.Location.X + to.Size.Width + size, to.Location.Y + to.Size.Height / 2 + 10);
            }
            else
                locationRectangle = to.Location;

            if (Path.PointCount > 0)
                _points = Path.PathPoints;
            if (Path.PointCount != 4 || _points[0] != from.Location || _points[3] != to.Location ||
                _points[1].X != LedgePositionX)
            {
                Path.Reset();

                Path.AddLines(new PointF[]
                {
                    new PointF(from.Location.X + from.Size.Width / 2, from.Location.Y + from.Size.Height / 2),
                    new PointF(LedgePositionX, from.Location.Y + from.Size.Height / 2),
                    new PointF(LedgePositionX, locationRectangle.Y),
                    locationRectangle
                });
            }
        }
    }
}