using System.Drawing;
using UML_Logic_Library.AdditionalClasses;

namespace UML_Logic_Library.StructuralEntities
{
    public class RectangleField : RectangleComponent
    {
        private const string ClassTypeName = "RectangleField";
        public new readonly TextField Text = new TextField();
        public RectangleF Rect;
        public RectangleF TextRect;

        public RectangleField(int rectHeight)
        {
            var rectHeight1 = rectHeight;
            Rect = new RectangleF(-DefaultSize, -DefaultSize / 2 + rectHeight1, 2 * DefaultSize, DefaultSize);
            TextRect = new RectangleF(-DefaultSize + 3, -DefaultSize / 2 + 2 + rectHeight1, 2 * DefaultSize - 6,
                DefaultSize - 4);
        }
        
        public new Rectangle TextBounds
        {
            get
            {
                return new Rectangle((int)(TextRect.Left + Location.X), (int)(TextRect.Top + Location.Y), (int)TextRect.Width, (int)TextRect.Height);
            }
        }
    }
}