using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Database_Library.BlackBox
{
    public class LiveDataElem
    {   
        // Элемент в диаграмме
        public int _id { get; set; }
        public string _name { get; set; }
        public Type _type { get; set; }
        public double _lenX { get; set; }
        public double _lenY { get; set; }
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
