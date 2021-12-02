using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting.Messaging;

namespace UML_Logic_Library
{
    public class RectangleOneField : SimpleRectangle
    {
        private PropField Head = new PropField(0);
        private PropField FieldProp = new PropField(DefaultSize);
        public TextField TextFieldTitle;
        public TextField TextFieldProperty;

        private RectangleF[] rect = new RectangleF[2];
        private RectangleF[] textRect = new RectangleF[2];

        public RectangleOneField()
        {
            rect[0] = Head.rect;
            rect[1] = FieldProp.rect;
            TextFieldTitle = Head.Text;
            TextFieldProperty = FieldProp.Text;
           
            Path.AddRectangles(rect);
        }

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

        public override void Scale(float scaleX, float scaleY)
        {
            //масштабируем линии
            Matrix m = new Matrix();
            m.Scale(scaleX, scaleY);
            Path.Transform(m);
            //масштабируем прямоугольник текста
            Head.textRect = new RectangleF(
                Head.textRect.Left * scaleX, 
                Head.textRect.Top * scaleY,
                Head.textRect.Width * scaleX, 
                Head.textRect.Height * scaleY
                );
            FieldProp.textRect = new RectangleF(
                FieldProp.textRect.Left * scaleX, 
                FieldProp.textRect.Top * scaleY, 
                FieldProp.textRect.Width * scaleX, 
                FieldProp.textRect.Height * scaleY
                );

        }

        public override void Draw(Graphics gr)
        {
            GraphicsState transState = gr.Save();
            gr.TranslateTransform(Location.X, Location.Y);
            gr.FillPath(Brush, Path);
            gr.DrawPath(Pen, Path);
            gr.DrawString(TextFieldTitle.TextFields, SystemFonts.DefaultFont, Brushes.Black, 
                Head.textRect, Head.Text.StringFormatTitle);
            gr.DrawString(TextFieldProperty.TextFieldsProp, SystemFonts.DefaultFont, Brushes.Black, 
                FieldProp.textRect, FieldProp.Text.StringFormatField);
            gr.Restore(transState);
        }
    }

    
}