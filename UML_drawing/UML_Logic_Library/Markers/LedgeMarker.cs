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
            Arrows.Arrows arrow = (TargetComponent as Arrows.Arrows);
            if (arrow != null && (arrow.From == null || arrow.To == null))
                return;
            //не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            var from = arrow.From as SimpleRectangle;
            var to = arrow.To as SimpleRectangle;
            Location = new PointF(arrow.LedgePositionX, (from.Location.Y + from.Size.Height/2 + to.Location.Y) / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, 0);
            ((Arrows.Arrows) TargetComponent).LedgePositionX += dx;
        }
    }
}