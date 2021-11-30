using System.Collections.Generic;
using System.Drawing;
using UML_Logic_Library.Interfaces;

namespace UML_Logic_Library.Markers
{
    public abstract class Marker : SimpleRectangle
    {
        private readonly int _defaultSize;
        public Component targetComponent;
        private List<Marker> _markers;

        public virtual System.Windows.Forms.Cursor Cursor
        {
            get { return System.Windows.Forms.Cursors.SizeNWSE; }
        }

        public Marker()
        {
            Color = Color.Red;
        }

        public virtual string ToolTip
        {
            get { return ToString(); }
        }

        public bool PointIsInside(PointF p)
        {
            if (p.X < Location.X - DefaultSize || p.X > Location.X + DefaultSize)
                return false;
            if (p.Y < Location.Y - DefaultSize || p.Y > Location.Y + DefaultSize)
                return false;

            return true;
        }

        public abstract void UpdateLocation();
        
    }
}