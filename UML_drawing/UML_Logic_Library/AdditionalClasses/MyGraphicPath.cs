using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace UML_Logic_Library.AdditionalClasses
{
    public class MyGraphicPath
    {
        public GraphicsPath path = new GraphicsPath();

        public MyGraphicPath()
        {
        }

        private MyGraphicPath(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount > 0)
            {
                PointF[] points = (PointF[])info.GetValue("point", typeof(PointF[]));
                byte[] types = (byte[])info.GetValue("type", typeof(byte[]));
                path = new GraphicsPath(points, types);
            }
            else
                path = new GraphicsPath();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (path.PointCount > 0)
            {
                info.AddValue("point", path.PathPoints);
                info.AddValue("type", path.PathTypes);
            }
        }
    }
}