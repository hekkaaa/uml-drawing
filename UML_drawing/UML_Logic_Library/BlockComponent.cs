using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Mime;
using Microsoft.SqlServer.Server;
using UML_Logic_Library.Interfaces;
using UML_Logic_Library.Requests.Abstract;

namespace UML_Logic_Library
{
    [Serializable]
    public abstract class BlockComponent : IComponent
    {
        public int ItemId { get; set; }
        public string text = "Title";

        public string Text
        {
            get => text;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("");
                text = value;
            }
        }
        readonly SerializableGraphicsPath serializablePath = new SerializableGraphicsPath();
        protected GraphicsPath Path { get { return serializablePath.path; } }
        readonly SerializableGraphicsPath serializableContour = new SerializableGraphicsPath();
        protected GraphicsPath Contour
        {
            get { return serializableContour.path; }
        }
        private Color _color = Color.White;
        private Color _penColor = Color.Black;
        protected Pen _pen;
        private float _penWidth = 1;
        protected Brush _brush;

        public Color Color
        {
            get { return _color; }
            set { _color = value; _brush = null; }
        }

        public virtual Brush Brush
        {
            get {
                if (_brush == null)
                    _brush = new SolidBrush(_color);
                return _brush;
            }
        }
        
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
        
        // public void SetId(int id)
        // {
        //     ItemId = id;
        // }

        public abstract IEnumerable<Marker> GetMarkers(Handler diagram);

        public virtual BlockComponent Clone()
        {
            return (BlockComponent) MemberwiseClone();
        }
        
        
    }
}