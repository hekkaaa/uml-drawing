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
            Line line = (TargetComponent as Line);
            if (line.From == null || line.To == null)
                return;
            //не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            var from = line.From as SimpleRectangle;
            var to = line.To as SimpleRectangle;
            Location = new PointF(line.LedgePositionX, (from.Location.Y + to.Location.Y) / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, 0);
            (TargetComponent as Line).LedgePositionX += dx;
        }
    }
}