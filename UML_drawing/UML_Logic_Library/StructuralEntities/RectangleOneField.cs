using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using UML_Logic_Library.AdditionalClasses;

namespace UML_Logic_Library.StructuralEntities
{
    [Serializable]
    public class RectangleOneField : SimpleRectangle
    {
        public string CompName => "RectangleOneField";
        public RectangleField Head = new RectangleField(0);
        public RectangleField FieldRectangle = new RectangleField(DefaultSize);
        
        private readonly RectangleF[] _rect = new RectangleF[2];
        private RectangleF[] _textRect = new RectangleF[2];

        public RectangleOneField()
        {
            _rect[0] = Head.Rect;
            _rect[1] = FieldRectangle.Rect;
            
            Path.AddRectangles(_rect);
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
                Head.TextRect.Top * scaleY,
                Head.TextRect.Width * scaleX, 
                Head.TextRect.Height * scaleY
                );
            FieldRectangle.TextRect = new RectangleF(
                FieldRectangle.TextRect.Left * scaleX, 
                FieldRectangle.TextRect.Top * scaleY, 
                FieldRectangle.TextRect.Width * scaleX, 
                FieldRectangle.TextRect.Height * scaleY
                );

        }

        public override void Draw(Graphics gr)
        {
            GraphicsState transState = gr.Save();
            gr.TranslateTransform(Location.X, Location.Y);
            gr.FillPath(Brush, Path);
            gr.DrawPath(Pen, Path);
            gr.DrawString(Head.Text.TextFields, Head.Text.Font, Brushes.Black, 
                Head.TextRect, Head.Text.StringFormatTitle);
            gr.DrawString(FieldRectangle.Text.TextFieldsProp, FieldRectangle.Text.Font, Brushes.Black, 
                FieldRectangle.TextRect, FieldRectangle.Text.StringFormatField);
            gr.Restore(transState);
        }
    }

    
}