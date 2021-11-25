using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Database_Library.BlackBox
{
    internal class LiveDataElem
    {   
        // Элемент в диаграмме
        public int id { get; set; }
        public string name { get; set; }
        public Type type { get; set; }
        public double lenX { get; set; }
        public double lenY { get; set; }
        double widthX { get; set; }
        double heightX { get; set; }
        double widthY { get; set; }
        double heightY { get; set; }
        Type backcolor { get; set; }
        Type fontcolor { get; set; }
        int thickness { get; set; }
        Type typefont { get; set; }
        string text { get; set; }
    }
}
