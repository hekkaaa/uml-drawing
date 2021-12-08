using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using UML_Logic_Library.AdditionalClasses;

namespace UML_Logic_Library.StructuralEntities
{
    [Serializable]
    public class RectangleTwoFields : SimpleRectangle
    {
        public string CompName => "RectangleTwoFields";
        public  RectangleField Head = new RectangleField(0);
        public  RectangleField FieldRectangle = new RectangleField(DefaultSize);
        public  RectangleField FieldMethods = new RectangleField(DefaultSize * 2);
        private readonly TextField _textFieldTitle;
        private readonly TextField _textFieldProperty;
        private readonly TextField _textFieldMethods;

        private readonly RectangleF[] _rect = new RectangleF[3];
        private RectangleF[] _textRect = new RectangleF[3];

        public RectangleTwoFields()
        {
            _rect[0] = Head.Rect;
            _rect[1] = FieldRectangle.Rect;
            _rect[2] = FieldMethods.Rect;
            _textFieldTitle = Head.Text;
            _textFieldProperty = FieldRectangle.Text;
            _textFieldMethods = FieldMethods.Text;

            Path.AddRectangles(_rect);
        }

        public override SizeF Size
        {
            get => Path.GetBounds().Size;
            set
            {
                SizeF oldSize = Path.GetBounds().Size;
                SizeF newSize = new SizeF(Math.Max(1, value.Width), Math.Max(1, value.Height));
                //коэффициент шкалировани по x
                float kx = newSize.Width / oldSize.Width;
                //коэффициент шкалировани по y
                float ky = newSize.Height / oldSize.Height ;
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
            Head.TextRect = new RectangleF(
                Head.TextRect.Left * scaleX,
                Head.TextRect.Top  * scaleY,
                Head.TextRect.Width * scaleX,
                Head.TextRect.Height * scaleY 
            );
            FieldRectangle.TextRect = new RectangleF(
                FieldRectangle.TextRect.Left * scaleX,
                FieldRectangle.TextRect.Top * scaleY,
                FieldRectangle.TextRect.Width * scaleX,
                FieldRectangle.TextRect.Height * scaleY
            );
            FieldMethods.TextRect = new RectangleF(
                FieldMethods.TextRect.Left * scaleX,
                FieldMethods.TextRect.Top * scaleY,
                FieldMethods.TextRect.Width * scaleX,
                FieldMethods.TextRect.Height * scaleY
            );
        }

        public override void Draw(Graphics gr)
        {
            GraphicsState transState = gr.Save();
            gr.TranslateTransform(Location.X, Location.Y);
            gr.FillPath(Brush, Path);
            gr.DrawPath(Pen, Path);
            gr.DrawString(_textFieldTitle.TextFields, _textFieldTitle.Font, Brushes.Black,
                Head.TextRect, Text.StringFormatTitle);
            gr.DrawString(_textFieldProperty.TextFieldsProp, _textFieldProperty.Font, Brushes.Black,
                FieldRectangle.TextRect, Text.StringFormatField);
            gr.DrawString(_textFieldMethods.TextFieldsMethod, _textFieldMethods.Font, Brushes.Black,
                FieldMethods.TextRect, Text.StringFormatField);
            gr.Restore(transState);
        }
        
    }
}