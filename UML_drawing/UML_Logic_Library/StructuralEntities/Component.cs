using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using UML_Logic_Library.AdditionalClasses;
using UML_Logic_Library.Markers;

namespace UML_Logic_Library.StructuralEntities
{
    [Serializable]
    public abstract class Component 
    {
        private MyGraphicPath _myGraphicPath = new MyGraphicPath();
        public GraphicsPath Path { get => _myGraphicPath.path;
            set => _myGraphicPath.path = value;
        }
        private Color _penColor = Color.Black;
        private float _penWidth = 1;
        [NonSerialized]
        protected Pen _pen;
        
        public virtual Pen Pen
        {
            get => _pen ??= new Pen(_penColor, _penWidth); 
            set
            {
                _pen = value;
            }
        }

        public Color PenColor
        {
            get => _penColor;
            set { _penColor = value; _pen = null; }
        }

        public float PenWidth
        {
            get => _penWidth;
            set { _penWidth = value; _pen = null; }
        }

        public abstract bool PointIsInside(PointF p);

        public abstract IEnumerable<Marker> GetMarkers(Handler handler);

        public abstract void Draw(Graphics gr);

    }
}