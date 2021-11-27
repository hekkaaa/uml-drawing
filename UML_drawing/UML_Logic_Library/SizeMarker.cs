using System.Drawing;

namespace UML_Logic_Library
{
    public class SizeMarker : Marker
    {
        public override void UpdateLocation()
        {
            RectangleF bounds = ((SingleBlock) targetComponent).Bounds;
            Location = new PointF(bounds.Right + defaultSize / 2, bounds.Bottom + defaultSize / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);
            ((SingleBlock) targetComponent).Size =
                SizeF.Add(((SingleBlock) targetComponent).Size, new SizeF(dx * 2, dy * 2));
        }
    }
}