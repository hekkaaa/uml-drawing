using System.Drawing;

namespace UML_Logic_Library
{
    public class PropField : RectangleComponent
    {
        public int RectHeight;
        public TextField Text = new TextField();
        public RectangleF rect;
        public RectangleF textRect;

        public PropField(int rectHeight)
        {
            RectHeight = rectHeight;
            rect = new RectangleF(-DefaultSize, -DefaultSize / 2 + RectHeight, 2 * DefaultSize, DefaultSize);
            textRect = new RectangleF(-DefaultSize + 3, -DefaultSize / 2 + 2 + RectHeight, 2 * DefaultSize - 6,
                DefaultSize - 4);
        }
        
        public Rectangle TextBounds
        {
            get
            {
                return new Rectangle((int)(textRect.Left + Location.X), (int)(textRect.Top + Location.Y), (int)textRect.Width, (int)textRect.Height);
            }
        }
    }
}