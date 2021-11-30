using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using UML_Logic_Library.Helpers;
using UML_Logic_Library.Markers;
using UML_Logic_Library.Requests;
using UML_Logic_Library.Requests.Abstract;

namespace UML_Logic_Library
{
    public class SimpleRectangle : Component
    {
        
        //размер новой фигуры, по умолчанию
        public int DefaultSize = 40;
        //местоположение центра фигуры
        public PointF Location;
        public TextField Text { get; set; }
        //прямоугольник, в котором расположен текст
        public RectangleF TextRect;
        private Color _color = Color.White;
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
        
        // public SimpleRectangle(){ }
        
        public override bool PointIsInside(PointF p)
        {
            return Path.IsVisible(p.X - Location.X, p.Y - Location.Y);
        }
        
        
        public override IEnumerable<Marker> GetMarkers()
        {
            Marker m = new SizeMarker();
            m.targetComponent = (SimpleRectangle)this;
            yield return m;
            
        }
        
        //прямоугольник вокруг фигуры 
        public virtual RectangleF Bounds
        {
            get
            {
                RectangleF bounds = Path.GetBounds();
                return new RectangleF(bounds.Left + Location.X, bounds.Top + Location.Y, bounds.Width, bounds.Height);
            }
        }
        //
        // //прямоугольник текста (в абсолютных координатах)
        // public Rectangle TextBounds
        // {
        //     get
        //     {
        //         return new Rectangle((int)(TextRect.Left + Location.X), (int)(TextRect.Top + Location.Y), (int)TextRect.Width, (int)TextRect.Height);
        //     }
        // }
        
        //размер прямоугольника вокруг фигуры
        public SizeF Size
        {
            get { return Path.GetBounds().Size; }
            set
            {
                SizeF oldSize = Path.GetBounds().Size;
                SizeF newSize = new SizeF(Math.Max(1, value.Width), Math.Max(1, value.Height));
                //коэффициент шкалировани по x
                float kx = newSize.Width / oldSize.Width;
                //коэффициент шкалировани по y
                float ky = newSize.Height / oldSize.Height;
                Scale(kx, ky);
            }
        }
        
        //изменение масштаба фигуры
        public virtual void Scale(float scaleX, float scaleY)
        {
            //масштабируем линии
            Matrix m = new Matrix();
            m.Scale(scaleX, scaleY);
            Path.Transform(m);
            //масштабируем прямоугольник текста
            TextRect = new RectangleF(TextRect.Left * scaleX, TextRect.Top * scaleY, TextRect.Width * scaleX, TextRect.Height * scaleY);
        }
        
        //сдвиг местоположения фигуры
        public virtual void Offset(float dx, float dy)
        {
            Location = Location.Offset(dx, dy);
            if(Location.X < 0)
                Location.X = 0;
            if (Location.Y < 0)
                Location.Y = 0;
        }
        
        public override void Draw(Graphics gr)
        {
            GraphicsState transState = gr.Save();
            gr.TranslateTransform(Location.X, Location.Y);
            gr.FillPath(Brush, Path);
            gr.DrawPath(Pen, Path);
            RectangleF rectF1 = new RectangleF(Bounds.Left - 2, Bounds.Top - 2, Bounds.Width + 4, Bounds.Height + 4);
            gr.DrawString(Text.TextFields, Text.Font, Brushes.Black, rectF1, Text.StringFormatTitle);
            gr.DrawRectangle(Pen,Rectangle.Round(rectF1) );
            gr.Restore(transState);
        }
        
    }
}