using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UML_Logic_Library
{
    public class RectangleTwoFields : RectangleComponent
    {
        private PropField Head = new PropField(0);
        private PropField FieldProp = new PropField(DefaultSize);
        private PropField FieldMethods = new PropField(DefaultSize * 2);
        private RectangleF TextRect;
        private RectangleF TextRect1;
        private RectangleF TextRect2;

        private RectangleF[] rect = new RectangleF[3];
        private RectangleF[] textRect = new RectangleF[3];
        private RectangleF _textRectHead;
        private RectangleF _textRectFieldProp;
        private RectangleF _textRectFieldMethods;

        public Rectangle TextBounds
        {
            get
            {
                return new Rectangle((int) (
                        TextRect.Left + Location.X), 
                    (int) (TextRect.Top + Location.Y),
                    (int) TextRect.Width, 
                    (int) TextRect.Height
                    );
            }
        }

        public Rectangle TextBounds1
        {
            get
            {
                return new Rectangle((int) (
                        TextRect.Left + Location.X),
                    (int) (TextRect.Top + Location.Y + FieldProp.RectHeight), 
                    (int) TextRect.Width,
                    (int) TextRect.Height);
            }
        }

        public Rectangle TextBounds2
        {
            get
            {
                return new Rectangle(
                    (int) (TextRect.Left + Location.X),
                    (int) (TextRect.Top + Location.Y + FieldMethods.RectHeight), 
                    (int) TextRect.Width,
                    (int) TextRect.Height
                    );
            }
        }

        public RectangleTwoFields()
        {
            rect[0] = Head.rect;
            rect[1] = FieldProp.rect;
            rect[2] = FieldMethods.rect;
            _textRectHead = Head.textRect;
            _textRectFieldProp = FieldProp.textRect;
            _textRectFieldMethods = FieldMethods.textRect;

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
            _textRectFieldMethods = new RectangleF(
                _textRectFieldMethods.Left * scaleX,
                _textRectFieldMethods.Top * scaleY,
                _textRectFieldMethods.Width * scaleX,
                _textRectFieldMethods.Height * scaleY
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
            gr.DrawString(Text.TextFieldsMethod, SystemFonts.DefaultFont, Brushes.Black,
                _textRectFieldMethods, Text.StringFormatField);
            gr.Restore(transState);
        }
        
    }
}