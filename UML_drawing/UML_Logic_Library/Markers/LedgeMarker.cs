using System.Drawing;

namespace UML_Logic_Library.Markers
{
    public class LedgeMarker : Marker
    {
        public override void UpdateLocation()
        {
            Line line = (targetComponent as Line);
            if (line.From == null || line.To == null)
                return;//не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            Location = new PointF(line.ledgePositionX, (line.From.Location.Y + line.To.Location.Y) / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, 0);
            (targetComponent as Line).ledgePositionX += dx;
        }
    }
}