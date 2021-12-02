using System.Drawing;

namespace UML_Logic_Library.Requests.Abstract
{
    public interface IComponentRequest
    {
        public int ItemId { get; set; }
        public Color Color { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public TextField Text { get; set; }
    }
}