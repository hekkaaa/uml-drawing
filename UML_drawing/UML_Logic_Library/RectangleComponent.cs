using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Logic_Library
{
    public class RectangleComponent : SimpleRectangle
    {
        public RectangleComponent() 
        {
            Path.AddRectangle(new RectangleF(-DefaultSize, -DefaultSize / 2, 2 * DefaultSize, DefaultSize));
            textRect = new RectangleF(-DefaultSize + 3, -DefaultSize / 2 + 2, 2 * DefaultSize - 6, DefaultSize - 4);
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
