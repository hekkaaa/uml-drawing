using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace UML_Logic_Library
{
    public class SerializableGraphicsPath
    {
        public GraphicsPath path = new GraphicsPath();

        public SerializableGraphicsPath(){ }

        // private SerializableGraphicsPath(SerializationInfo info, StreamingContext context)
        // {
        //     if (info.MemberCount > 0)
        //     {
        //         PointF[] points = (PointF[])info.GetValue("p", typeof(PointF[]));
        //         byte[] types = (byte[])info.GetValue("t", typeof(byte[]));
        //         path = new GraphicsPath(points, types);
        //     }
        //     else
        //         path = new GraphicsPath();
        // }

        // public void GetObjectData(SerializationInfo info, StreamingContext context)
        // {
        //     if (path.PointCount > 0)
        //     {
        //         info.AddValue("p", path.PathPoints);
        //         info.AddValue("t", path.PathTypes);
        //     }
        // }
    }
}