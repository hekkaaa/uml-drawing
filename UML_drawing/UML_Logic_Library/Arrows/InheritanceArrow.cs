using System.Drawing;
using System.Drawing.Drawing2D;

namespace UML_Logic_Library.Arrows
{
    public class InheritanceArrow : Line
    {
        public override Pen Pen
        {
            get 
            {
                Pen p = new Pen(PenColor,PenWidth);
                p.CustomEndCap = new AdjustableArrowCap(15, 15, false);
                p.DashStyle = DashStyle.Dash;
                p.DashPattern = new float[] {2,3};
                return p;
            }
        }
    }
}