﻿using System.Collections.Generic;
using UML_Logic_Library.Interfaces;

namespace UML_Logic_Library.Markers
{
    public class EndLineMarker : Marker
    {
        int pointIndex;
        List<IComponent> components;

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

            //ищем фигуру под маркером
            SimpleRectangle figure = this;

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