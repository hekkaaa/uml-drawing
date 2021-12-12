using System;
using System.Drawing;
using UML_Logic_Library.AdditionalClasses;

namespace UML_Logic_Library.StructuralEntities
{
    [Serializable]
    public class RectangleComponent : SimpleRectangle
    {
        public RectangleComponent() 
        {
            Path.AddRectangle(new RectangleF(0, 0, 2 * DefaultSize, DefaultSize));
            TextRect = new RectangleF(3, 2, 2 * DefaultSize - 6, DefaultSize - 4);
        }
        
        public Rectangle TextBounds => new((int)(TextRect.Left + Location.X), (int)(TextRect.Top + Location.Y), (int)TextRect.Width, (int)TextRect.Height);
    }
}
