using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using UML_Logic_Library.AdditionalClasses;

namespace UML_Logic_Library.StructuralEntities
{
    [Serializable]
    public class RectangleOneField : SimpleRectangle
    {
        public RectangleField Head = new RectangleField(0);
        public RectangleField FieldProp = new RectangleField(DefaultSize);
        
        private readonly RectangleF[] _rect = new RectangleF[2];
        private RectangleF[] _textRect = new RectangleF[2];

        public RectangleOneField()
        {
            _rect[0] = Head.Rect;
            _rect[1] = FieldProp.Rect;
            
            Path.AddRectangles(_rect);
        }

        public override void Scale(float scaleX, float scaleY)
        {
            //масштабируем линии
            Matrix m = new Matrix();
            m.Scale(scaleX, scaleY);
            Path.Transform(m);
            //масштабируем прямоугольники текста
            Head.TextRect = new RectangleF(
                Head.TextRect.Left * scaleX, 
                Head.TextRect.Top * scaleY,
                Head.TextRect.Width * scaleX, 
                Head.TextRect.Height * scaleY
                );
            FieldProp.TextRect = new RectangleF(
                FieldProp.TextRect.Left * scaleX, 
                FieldProp.TextRect.Top * scaleY, 
                FieldProp.TextRect.Width * scaleX, 
                FieldProp.TextRect.Height * scaleY
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
            gr.DrawString(FieldProp.Text.TextFieldsProp, FieldProp.Text.Font, Brushes.Black, 
                FieldProp.TextRect, FieldProp.Text.StringFormatField);
            gr.Restore(transState);
        }
    }

    
}