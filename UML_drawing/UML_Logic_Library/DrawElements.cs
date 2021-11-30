using System.Drawing;
using System.IO;

namespace UML_Logic_Library
{
    public static class DrawElements
    {
        public static void DrawLine(this Line line, Graphics gr)
        {
            if (line.From == null || line.To == null)
                return;

            line.RecalcPath();
            gr.DrawPath(line.Pen, line.Path);
        }


    }
}