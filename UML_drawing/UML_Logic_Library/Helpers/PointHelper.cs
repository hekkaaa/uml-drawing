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

        public static float Length(this PointF p)
        {
            return (float)Math.Sqrt(p.X * p.X + p.Y * p.Y);
        }

        public static PointF Sub(this PointF p, PointF p1)
        {
            return new PointF(p.X-p1.X, p.Y - p1.Y);
        }

        public static PointF Mult(this PointF p, float k)
        {
            return new PointF(k*p.X, k*p.Y);
        }

        public static PointF Mult(this PointF p, float kx, float ky)
        {
            return new PointF(kx * p.X, ky * p.Y);
        }

        public static PointF Add(this PointF p, PointF p1)
        {
            return new PointF(p.X + p1.X, p.Y + p1.Y);
        }

        public static float FromTo(this float k, float a, float b)
        {
            return (a * (1 - k) + b * k);
        }

        public static PointF FromTo(this float k, PointF a, PointF b)
        {
            return new PointF(k.FromTo(a.X, b.X), k.FromTo(a.Y, b.Y));
        }

        public static string FirstCharUpper(this string s)
        {
            if(string.IsNullOrEmpty(s))
                return s;
            if(s.Length==1)
                return s.ToUpper();

            return char.ToUpper(s[0]) + s.Substring(1);
        }


        public static float Angle(this PointF A, PointF B)
        {
            return (float)(180f * (Math.Atan2(A.Y, A.X) - Math.Atan2(B.Y, B.X)) / Math.PI);
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