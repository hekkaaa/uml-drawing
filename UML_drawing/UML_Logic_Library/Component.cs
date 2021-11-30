using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Mime;
using Microsoft.SqlServer.Server;
using UML_Logic_Library.Interfaces;
using UML_Logic_Library.Markers;
using UML_Logic_Library.Requests.Abstract;

namespace UML_Logic_Library
{
    [Serializable]
    public abstract class Component : IComponent
    {
        public int ItemId { get; set; }
        //readonly GraphicsPath _graphicsPath = new GraphicsPath();
        public GraphicsPath Path => new GraphicsPath();
        private Color _penColor = Color.Black;
        protected Pen _pen;
        private float _penWidth = 5;
        
        public virtual Pen Pen
        {
            get {
                if (_pen == null)
                    _pen = new Pen(_penColor, _penWidth);
                return _pen;
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

        public abstract IEnumerable<Marker> GetMarkers();

        public abstract void Draw(Graphics gr);

    }
}