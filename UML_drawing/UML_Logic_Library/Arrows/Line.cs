using System.Collections.Generic;
using System.Drawing;
using UML_Logic_Library.Markers;

namespace UML_Logic_Library.Arrows
{
    public enum Arrows
    {
        Simple,
        SolidArrow,
        LineArrow,
        SolidDiamond,
        LoneDiamond
    }
    public class Line : Component
    {
        
            public SimpleRectangle From;
            public SimpleRectangle To;

            public PointF[] Points;
            //static Pen clickPen = new Pen(Color.Transparent, 3);
            internal float ledgePositionX = -1;
            
            public override IEnumerable<Marker> GetMarkers(Handler components)
            {
                RecalcPath();
                EndLineMarker m1 = new EndLineMarker(components, 0);
                m1.targetComponent = this;
                yield return m1;

                EndLineMarker m2 = new EndLineMarker(components, 1);
                m2.targetComponent = this;
                yield return m2;

                LedgeMarker m3 = new LedgeMarker();
                m3.targetComponent = this;
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
            
            
            public override void Draw(Graphics gr)
            {
                if (From == null || To == null)
                    return;

                RecalcPath();
                gr.DrawLines(Pen, Points);
            }

            public void RecalcPath()
            {
                Points = null;

                if (ledgePositionX < 0)
                    ledgePositionX = (From.Location.X + To.Location.X) / 2;

                if (Path.PointCount > 0)
                    Points = Path.PathPoints;
                if (Path.PointCount != 4 || Points[0] != From.Location || Points[3] != To.Location ||
                    Points[1].X!=ledgePositionX)
                {
                    Path.Reset();
                    Path.AddLines(new PointF[]{
                        From.Location,
                        new PointF(ledgePositionX, From.Location.Y),
                        new PointF(ledgePositionX, To.Location.Y),
                        To.Location
                    });
                }
            }
            
    }
}