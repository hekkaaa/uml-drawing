using System.Drawing;
using NUnit.Framework;
using UML_Logic_Library.StructuralEntities;

namespace TestProject.LogicalTest
{
    [TestFixture]
    public class SimpleRectangleTest
    {
        private RectangleComponent _rectangle;
        
        [SetUp]
        public void Start()
        {
            _rectangle = new RectangleComponent()
            {
                Location = new PointF(10,5)
            };
        }

        [TestCase(2, 1.5f, 320, 120)]
        [TestCase(1, 2.5f, 160, 200)]
        [TestCase(5, 1, 800, 80)]
        public void ScaleTest(float x, float y, int width, int height)
        {
            _rectangle.Scale(x,y);
            Assert.AreEqual(width, _rectangle.Size.Width);
            Assert.AreEqual(height, _rectangle.Size.Height);
        }
        
        [TestCase(2, 10, 12, 15)]
        [TestCase(115, -39, 125, 0)]
        [TestCase(-29, 78, 0, 83)]
        [TestCase(-2, -2, 8, 3)]
        public void OffsetTest(float x, float y, int xe, int ye)
        {
            _rectangle.Offset(x,y);
            Assert.AreEqual(new PointF(xe,ye), _rectangle.Location);
        }
        
        [TestCase(110,70,true)]
        [TestCase(2,0,false)]
        public void PointIsInsideTest(float x, float y, bool expected)
        {
            var actual = _rectangle.PointIsInside(new PointF(x, y));
            Assert.AreEqual(expected, actual);
        }
    }
}