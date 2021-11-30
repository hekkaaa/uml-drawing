using System.Collections.Generic;
using System.Drawing;
using UML_Logic_Library.Markers;

namespace UML_Logic_Library
{
    public class Line : Component
    {
        
            public SimpleRectangle From;
            public SimpleRectangle To;
            static Pen clickPen = new Pen(Color.Transparent, 3);
            internal float ledgePositionX = -1;

            public IEnumerable<Marker> GetMarkers(Handler components)
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
                return Path.IsOutlineVisible(p, clickPen);            
            }

            public override IEnumerable<Marker> GetMarkers()
            {
                throw new System.NotImplementedException();
            }

            public override void Draw(Graphics gr)
            {
                throw new System.NotImplementedException();
            }

            public void RecalcPath()
            {
                PointF[] points = null;

                if (ledgePositionX < 0)
                    ledgePositionX = (From.Location.X + To.Location.X) / 2;

                if (Path.PointCount > 0)
                    points = Path.PathPoints;
                if (Path.PointCount != 4 || points[0] != From.Location || points[3] != To.Location ||
                    points[1].X!=ledgePositionX)
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