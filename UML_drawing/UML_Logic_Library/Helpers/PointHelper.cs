using System;
using System.Drawing;

namespace UML_Logic_Library.Helpers
{
    public static class PointHelper
    {
        public static PointF Offset(this PointF p, float x, float y)
        {
            p.X = p.X + x;
            p.Y = p.Y + y;
            return p;
        }

        public static PointF[] FlipByX(this PointF[] points)
        {
            Array.Reverse(points);
            for (int i = 0; i < points.Length; i++)
                points[i].X *= -1f;
            return points;
        }
    }
}