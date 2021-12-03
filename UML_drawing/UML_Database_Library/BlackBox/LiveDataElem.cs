using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Database_Library.BlackBox
{
    public class LiveDataElem
    {
        // Элемент в диаграмме
        public int _id { get; set; }
        public Color _penColor { get; set; }
        //public Pen _pen { get; set; }
        public float _penWidth { get; set; }
        public GraphicsPath Path { get; set; }

        //double widthX { get; set; }
        //double heightX { get; set; }
        //double widthY { get; set; }
        //double heightY { get; set; }
        //Type backcolor { get; set; }
        //Type fontcolor { get; set; }
        //int thickness { get; set; }
        //Type typefont { get; set; }
        //string text { get; set; }
    }
}
