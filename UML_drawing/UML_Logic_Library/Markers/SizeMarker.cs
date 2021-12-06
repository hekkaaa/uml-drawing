using System.Drawing;
using UML_Logic_Library.StructuralEntities;

namespace UML_Logic_Library.Markers
{
    public class SizeMarker : Marker
    {
        public override void UpdateLocation()
        {
            RectangleF bounds = ((SimpleRectangle) targetComponent).Bounds;
            Location = new PointF(bounds.Right, bounds.Bottom);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);
            ((SimpleRectangle) targetComponent).Size =
                SizeF.Add(((SimpleRectangle) targetComponent).Size, new SizeF(dx * 2, dy * 2));
        }
    }
}