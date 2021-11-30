using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UML_Logic_Library.Helpers
{
    public static class GraphicPathHelper
    {
        public static void Transform(this GraphicsPath path, Func<PointF, PointF> func, bool accuracy)
        {
            //для более точных рассчетов, можно сделать Flatten
            if (accuracy)
                path.Flatten();
            //получаем точки изображения
            var data = path.PathData;
            //выполняем преобразование над каждой точкой
            for (int i = 0; i < data.Points.Length; i++)
                data.Points[i] = func.Invoke(data.Points[i]);
            //очищаем исходный контур
            path.Reset();
            //создаем новый конутр и присоединяем к исходному
            path.AddPath(new GraphicsPath(data.Points, data.Types), false);
        }

        public static void Transform(this GraphicsPath path, Func<PointF, PointF> func)
        {
            Transform(path, func, false);
        }
    }
}