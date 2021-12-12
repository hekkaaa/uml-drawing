using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UML_Logic_Library.StructuralEntities;

namespace UML_Logic_Library.Markers
{
    [Serializable]
    public abstract class Marker : SimpleRectangle
    {
        private readonly int _defaultSize = 3;
        public Component TargetComponent;
        private List<Marker> _markers;

        public virtual Cursor Cursor => Cursors.SizeNWSE;

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
        
        public override void Draw(Graphics gr)
        {
            gr.DrawRectangle(Pen, Location.X, Location.Y, _defaultSize, _defaultSize);
            gr.FillRectangle(Brush, Location.X, Location.Y, _defaultSize, _defaultSize);
        }
    }
}