using System.Drawing;
using System.Windows.Forms;
using UML_Logic_Library.Requests;

namespace UML_Logic_Library
{
    public abstract class Marker : SingleBlock
    {
        protected static new int defaultSize = 3;
        public BlockComponent targetComponent;
        
        public Marker()
        {
            Color = Color.Red;
        }

        public virtual string ToolTip
        {
            get { return ToString(); }
        }

        public virtual System.Windows.Forms.Cursor Cursor
        {
            get { return System.Windows.Forms.Cursors.SizeNWSE; }
        }

        public bool PointIsInside(PointF p)
        {
            if (p.X < Location.X - defaultSize || p.X > Location.X + defaultSize)
                return false;
            if (p.Y < Location.Y - defaultSize || p.Y > Location.Y + defaultSize)
                return false;

            return true;
        }


        public abstract void UpdateLocation();
    }
}
