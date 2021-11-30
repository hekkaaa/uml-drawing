using System.Drawing;

namespace UML_Logic_Library
{
    public class RectangleComponent : SimpleRectangle
    {
        public RectangleComponent()
        {
            Path.AddRectangle(new RectangleF(-DefaultSize, -DefaultSize/2, 2*DefaultSize, DefaultSize));
            TextRect = new RectangleF(-DefaultSize + 3, -DefaultSize / 2 + 2, 2 * DefaultSize - 6, DefaultSize - 4);
        }
    }
}