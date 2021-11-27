using System.Drawing;
using UML_Logic_Library.Requests.Abstract;

namespace UML_Logic_Library.Requests
{
    public class SingleBlockRequest : IBlockComponentRequest
    {
        public SizeF Size { get; set; }
        
        public PointF Location { get; set; }
        public int ItemId { get; set; }
        public Color Color { get; set; }
        public Brush Brush { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public string Text { get; set; }
    }
}