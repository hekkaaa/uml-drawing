﻿using System;
using System.Drawing;

namespace UML_Logic_Library.StructuralEntities
{
    [Serializable]
    public class RectangleComponent : SimpleRectangle
    {
        public string CompName => "RectangleComponent";
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
