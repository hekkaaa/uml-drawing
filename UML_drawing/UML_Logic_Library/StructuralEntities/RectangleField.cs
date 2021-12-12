using System;
using System.Drawing;
using UML_Logic_Library.AdditionalClasses;

namespace UML_Logic_Library.StructuralEntities
{
    [Serializable]
    public class RectangleField : RectangleComponent
    {
        public new readonly TextField Text = new TextField();
        public RectangleF Rect;
        public RectangleF TextRect;

        public RectangleField(int rectHeight)
        {
            var rectHeight1 = rectHeight;
            Rect = new RectangleF(0, 0 + rectHeight1, 2 * DefaultSize, DefaultSize);
            TextRect = new RectangleF(3, 2 + rectHeight1, 2 * DefaultSize - 6,
                DefaultSize - 4);
        }

        public RectangleField(RectangleF rect, RectangleF textRect)
        {
            Rect = rect;
            TextRect = textRect;
        }
        
        public new Rectangle TextBounds => new Rectangle((int)(TextRect.Left + Location.X), (int)(TextRect.Top + Location.Y), (int)TextRect.Width, (int)TextRect.Height);
    }
}