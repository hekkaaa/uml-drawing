
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using UML_Logic_Library.Markers;

namespace UML_Logic_Library.Interfaces
{
    public interface IComponent
    {
       int ItemId { get; set; }
       public GraphicsPath Path { get; }
       public Pen Pen { get; }
       public Color PenColor { get; set; }
       public float PenWidth { get; set; }
       
       public bool PointIsInside(PointF p);

       public IEnumerable<Marker> GetMarkers(Handler handler);

       public void Draw(Graphics gr);
    }
}