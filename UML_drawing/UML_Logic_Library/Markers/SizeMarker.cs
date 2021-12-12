using System;
using System.Drawing;
using UML_Logic_Library.StructuralEntities;

namespace UML_Logic_Library.Markers
{
    [Serializable]
    public class SizeMarker : Marker
    {
        public override void UpdateLocation()
        {
            RectangleF bounds = ((SimpleRectangle) TargetComponent).Bounds;
            Location = new PointF(bounds.Right, bounds.Bottom);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);
            ((SimpleRectangle) TargetComponent).Size =
                SizeF.Add(((SimpleRectangle) TargetComponent).Size, new SizeF(dx, dy));
        }
    }
}