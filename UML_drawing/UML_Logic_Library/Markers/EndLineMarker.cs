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
            Arrows.Arrows arrows = (TargetComponent as Arrows.Arrows);
            if (arrows.From == null || arrows.To == null)
                return;//не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            var from = arrows.From as SimpleRectangle;
            var to = arrows.To as SimpleRectangle;
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

            Arrows.Arrows arrows = (TargetComponent as Arrows.Arrows);
            if (figure == null)
                figure = this;
            //если под маркером нет фигуры, то просто коннектим линию к самому маркеру

            //не позволяем конектится самому к себе
            if (arrows.From == figure || arrows.To == figure)
                return;
            //обновляем конекторы линии
            if (pointIndex == 0)
                arrows.From = figure;
            else
                arrows.To = figure;

        }
    }
}