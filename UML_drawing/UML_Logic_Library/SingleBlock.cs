using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using UML_Logic_Library.Requests;
using UML_Logic_Library.Requests.Abstract;

namespace UML_Logic_Library
{
    public class SingleBlock : BlockComponent
    {
        //размер новой фигуры, по умолчанию
        public static int defaultSize = 40;
        //местоположение центра фигуры
        public PointF Location;
        //прямоугольник, в котором расположен текст
        protected RectangleF textRect;

        public SingleBlock()
        {
        }
        
        public override bool PointIsInside(PointF p)
        {
            return Path.IsVisible(p.X - Location.X, p.Y - Location.Y);
        }
        
        
        public override IEnumerable<Marker> GetMarkers(Handler diagram)
        {
            Marker m = new SizeMarker();
            m.targetComponent = this;
            yield return m;
            
        }

        //настройки вывода текста
        protected virtual StringFormat StringFormat
        {
            get {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                return stringFormat;
            }
        }
        
        
        //прямоугольник вокруг фигуры (в абсолютных координатах)
        public virtual RectangleF Bounds
        {
            get
            {
                RectangleF bounds = Path.GetBounds();
                return new RectangleF(bounds.Left + Location.X, bounds.Top + Location.Y, bounds.Width, bounds.Height);
            }
        }
        
        //прямоугольник текста (в абсолютных координатах)
        public Rectangle TextBounds
        {
            get
            {
                return new Rectangle((int)(textRect.Left + Location.X), (int)(textRect.Top + Location.Y), (int)textRect.Width, (int)textRect.Height);
            }
        }
        
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
            //масштабируем прямоугльник текста
            textRect = new RectangleF(textRect.Left * scaleX, textRect.Top * scaleY, textRect.Width * scaleX, textRect.Height * scaleY);
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
        
    }
}