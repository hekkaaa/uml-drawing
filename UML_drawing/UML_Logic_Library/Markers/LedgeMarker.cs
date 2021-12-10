using System;
using System.Drawing;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.StructuralEntities;

namespace UML_Logic_Library.Markers
{
    [Serializable]
    public class LedgeMarker : Marker
    {
        public override void UpdateLocation()
        {
            Arrows.Arrows arrows = (TargetComponent as Arrows.Arrows);
            if (arrows.From == null || arrows.To == null)
                return;
            //не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            var from = arrows.From as SimpleRectangle;
            var to = arrows.To as SimpleRectangle;
            Location = new PointF(arrows.LedgePositionX, (from.Location.Y + to.Location.Y) / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, 0);
            (TargetComponent as Arrows.Arrows).LedgePositionX += dx;
        }
    }
}