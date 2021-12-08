using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using UML_Logic_Library.AdditionalClasses;
using UML_Logic_Library.Interfaces;
using UML_Logic_Library.Markers;

namespace UML_Logic_Library.StructuralEntities
{
    [Serializable]
    public abstract class Component : IComponent
    {
        public int ItemId { get; set; }
        private MyGraphicPath _myGraphicPath = new MyGraphicPath();
        public GraphicsPath Path { get => _myGraphicPath.path;
            set => _myGraphicPath.path = value;
        }
        //public GraphicsPath SerializablePath => new GraphicsPath();
        private Color _penColor = Color.Black;
        private float _penWidth = 1;
        [NonSerialized]
        protected Pen _pen;
        
        public virtual Pen Pen
        {
            get {
                if (_pen == null)
                    _pen = new Pen(_penColor, _penWidth);
                return _pen;
            }
            set
            {
                _pen = value;
            }
        }

        public Color PenColor
        {
            get { return _penColor; }
            set { _penColor = value; _pen = null; }
        }

        public float PenWidth
        {
            get { return _penWidth; }
            set { _penWidth = value; _pen = null; }
        }

        public abstract bool PointIsInside(PointF p);

        public abstract IEnumerable<Marker> GetMarkers(Handler handler);

        public abstract void Draw(Graphics gr);

    }
}