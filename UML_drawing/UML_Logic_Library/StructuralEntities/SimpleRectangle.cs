using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using UML_Logic_Library.AdditionalClasses;
using UML_Logic_Library.Helpers;
using UML_Logic_Library.Markers;

namespace UML_Logic_Library.StructuralEntities
{
    [Serializable]
    public class SimpleRectangle : Component
    {
        //размер новой фигуры, по умолчанию
        public static int DefaultSize = 80;
        public PointF Location;
        public TextField Text = new TextField();
        private Color _color = Color.White;
        public RectangleF TextRect;
        [NonSerialized]
        protected Brush _brush;

        public Color Color
        {
            get => _color;
            set { _color = value; _brush = null; }
        }

        public virtual Brush Brush => _brush ??= new SolidBrush(_color);

        public SimpleRectangle(){ }
        
        public override bool PointIsInside(PointF p)
        {
            return Path.IsVisible(p.X - Location.X, p.Y - Location.Y);
        }
        
        
        public override IEnumerable<Marker> GetMarkers(Handler handler)
        {
            Marker m = new SizeMarker();
            m.TargetComponent = (SimpleRectangle)this;
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

        //размер прямоугольника вокруг фигуры
        public virtual SizeF Size
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
            gr.DrawString(Text.TextFields, Text.Font, Brushes.Black, TextRect, Text.StringFormatTitle);
            gr.Restore(transState);
        }
        
    }
}