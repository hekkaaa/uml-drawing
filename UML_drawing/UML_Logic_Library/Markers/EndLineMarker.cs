using System.Collections.Generic;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.Interfaces;

namespace UML_Logic_Library.Markers
{
    public class EndLineMarker : Marker
    {
        int pointIndex;
        List<Component> components;

        public EndLineMarker(Handler componentsList, int pointIndex)
        {
            this.components = componentsList.ComponentsInProj;
            this.pointIndex = pointIndex;
        }

        public override void UpdateLocation()
        {
            Line line = (targetComponent as Line);
            if (line.From == null || line.To == null)
                return;//не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            SimpleRectangle figure = pointIndex == 0 ? line.From : line.To;
            Location = figure.Location;
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);
            
            SimpleRectangle figure = null;
            for (int i = components.Count - 1; i >= 0; i--)
                if (components[i] is SimpleRectangle && components[i].PointIsInside(Location))
                {
                    figure = (SimpleRectangle)components[i];
                    break;
                }

            Line line = (targetComponent as Line);
            if (figure == null)
                figure = this;
            //если под маркером нет фигуры, то просто коннектим линию к самому маркеру

            //не позволяем конектится самому к себе
            if (line.From == figure || line.To == figure)
                return;
            //обновляем конекторы линии
            if (pointIndex == 0)
                line.From = figure;
            else
                line.To = figure;

        }
    }
}