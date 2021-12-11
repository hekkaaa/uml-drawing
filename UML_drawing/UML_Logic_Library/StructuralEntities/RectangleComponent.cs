using System;
using System.Drawing;
using UML_Logic_Library.AdditionalClasses;

namespace UML_Logic_Library.StructuralEntities
{
    [Serializable]
    public class RectangleComponent : SimpleRectangle
    {
        public string CompName => "RectangleComponent";
        public RectangleComponent() 
        {
            Path.AddRectangle(new RectangleF(0, 0, 2 * DefaultSize, DefaultSize));
            textRect = new RectangleF(3, 2, 2 * DefaultSize - 6, DefaultSize - 4);
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
