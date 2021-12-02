using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting.Messaging;

namespace UML_Logic_Library
{
    public class RectangleOneField : RectangleComponent
    {
        private PropField Head = new PropField(0);
        private PropField FieldProp = new PropField(DefaultSize);
        public RectangleF TextRect1;
        public RectangleF TextRect2;

        private RectangleF[] rect = new RectangleF[2];
        private RectangleF[] textRect = new RectangleF[2];
        private RectangleF _textRectHead;
        private RectangleF _textRectFieldProp;

        public Rectangle TextBounds1
        {
            get
            {
                return new Rectangle(
                    (int)(TextRect1.Left + Location.X), 
                    (int)(TextRect1.Top + Location.Y), 
                    (int)TextRect1.Width, 
                    (int)TextRect1.Height
                    );
            }
        }

        public Rectangle TextBounds2
        {
            get
            {
                return new Rectangle(
                    (int)(TextRect2.Left + Location.X ), 
                    (int)(TextRect2.Top + Location.Y + FieldProp.RectHeight), 
                    (int)TextRect2.Width, 
                    (int)TextRect2.Height + FieldProp.RectHeight
                    );
            }
        }

        public RectangleOneField()
        {
            rect[0] = Head.rect;
            rect[1] = FieldProp.rect;
            _textRectHead = Head.textRect;
            _textRectFieldProp = FieldProp.textRect;

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
            _textRectHead = new RectangleF(
                _textRectHead.Left * scaleX, 
                _textRectHead.Top * scaleY,
                _textRectHead.Width * scaleX, 
                _textRectHead.Height * scaleY
                );
            _textRectFieldProp = new RectangleF(
                _textRectFieldProp.Left * scaleX, 
                _textRectFieldProp.Top * scaleY, 
                _textRectFieldProp.Width * scaleX, 
                _textRectFieldProp.Height * scaleY
                );

        }

        public override void Draw(Graphics gr)
        {
            GraphicsState transState = gr.Save();
            gr.TranslateTransform(Location.X, Location.Y);
            gr.FillPath(Brush, Path);
            gr.DrawPath(Pen, Path);
            gr.DrawString(Text.TextFields, SystemFonts.DefaultFont, Brushes.Black, 
                _textRectHead, Text.StringFormatTitle);
            gr.DrawString(Text.TextFieldsProp, SystemFonts.DefaultFont, Brushes.Black, 
                _textRectFieldProp, Text.StringFormatField);
            gr.Restore(transState);
        }
    }

    
}