using System.Drawing;
using NUnit.Framework;
using TestProject.LogicalTest.Mocks;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.StructuralEntities;

namespace TestProject.LogicalTest
{
    [TestFixture]
    public class ArrowsTest
    {
        private ControlMock _control;
        private Arrows _arr;
        
        [SetUp]
        public void Start()
        {
            _control = new ControlMock();
            _arr = _control.Arrow;
        }

        [TestCase(0,0,80,40,105,40,105,180,117,180, ArrowsTypes.RealizationArrow)]
        [TestCase(130,80,210,120,170,120,170,180,316,180, ArrowsTypes.AggregationArrow)]
        [TestCase(20,100,100,140,115,140,115,180,130,180, ArrowsTypes.CompositionArrow)]
        public void RecalcPathTest(float x, float y, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4, ArrowsTypes type)
        {
            _arr.From = new RectangleComponent(){ Location = new PointF(x,y) };
            _arr.TypesType = type;
            _control.CreateMarkers();
            Assert.AreEqual(new PointF(x1,y1), _arr.Path.PathPoints[0]);
            Assert.AreEqual(new PointF(x2,y2), _arr.Path.PathPoints[1]);
            Assert.AreEqual(new PointF(x3,y3), _arr.Path.PathPoints[2]);
            Assert.AreEqual(new PointF(x4,y4), _arr.Path.PathPoints[3]);
        }
        
        [TestCase(110,70,true)]
        [TestCase(2,0,false)]
        public void PointIsInsideTest(float x, float y, bool expected)
        {
            var actual = _arr.PointIsInside(new PointF(x, y));
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(false)]
        public void PointIsInsideTest(bool expected)
        {
            _arr.To = null;
            _arr.From = null;
            var actual = _arr.PointIsInside(new PointF(20, 30));
            Assert.AreEqual(expected, actual);
        }
    }
}