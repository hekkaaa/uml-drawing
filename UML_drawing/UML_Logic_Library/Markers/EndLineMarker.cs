using System;
using System.Collections.Generic;
using UML_Logic_Library.AdditionalClasses;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.Interfaces;
using UML_Logic_Library.StructuralEntities;

namespace UML_Logic_Library.Markers
{
    [Serializable]
    public class EndLineMarker : Marker
    {
        public string CompName => "EndLineMarker";
        int pointIndex;
        List<Component> components;

        public EndLineMarker(Handler componentsList, int pointIndex)
        {
            this.components = componentsList.ComponentsInProj;
            this.pointIndex = pointIndex;
        }

        public override void UpdateLocation()
        {
            Line line = (TargetComponent as Line);
            if (line.From == null || line.To == null)
                return;//не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            var from = line.From as SimpleRectangle;
            var to = line.To as SimpleRectangle;
            SimpleRectangle figure = pointIndex == 0 ? from : to;
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

            Line line = (TargetComponent as Line);
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