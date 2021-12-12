using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using TestProject.LogicalTest.Mocks;
using UML_drawing;
using UML_Logic_Library.AdditionalClasses;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.Markers;
using UML_Logic_Library.StructuralEntities;

namespace TestProject.LogicalTest
{
    [TestFixture]
    public class MarkersTest
    {
        private ControlMock _control;
        private Arrows _arr;
        
        [SetUp]
        public void Start()
        {
            _control = new ControlMock();
            _arr = _control.Arrow;
        }

        [TestCase(100, 100, 105,85,  100,150)]
        [TestCase(50, 50, 80, 60,50,100)]
        [TestCase(0, 0, 55,35,  160,50)]
        public void UpdateLocationTest(float x, float y,float xe1, float ye1, float xe2, float ye2)
        {
            _arr.To = new RectangleComponent(){ Location = new PointF(x,y)};
            _control.CreateMarkers();
            var endMarker = _control.Markers[1];
            var ledgeMarker = _control.Markers[2];
            var expected1 = new PointF(xe1,ye1);
            var expected2 = new PointF(xe2,ye2);
            Assert.AreEqual(expected1.X, ledgeMarker.Location.X);
            Assert.AreEqual(expected1.Y, ledgeMarker.Location.Y);
            Assert.AreEqual(expected2.X, endMarker.Location.X);
            Assert.AreEqual(expected2.Y, endMarker.Location.Y);
        }

        [TestCase(80,60, true)]
        [TestCase(21,29, false)]
        [TestCase(110,70, true)]
        public void PointIsInsideTest(float x, float y, bool expected)
        {
            _control.CreateMarkers();
            Assert.AreEqual(expected, _control.Markers[0].PointIsInside(new PointF(x,y)));
        }
        
        [TestCase(80,60, 190, 130)]
        [TestCase(21,29, 131, 99)]
        public void OffsetTest(float x, float y, float xe, float ye)
        {
            _control.CreateMarkers();
            var m1 = _control.Markers[0];
            m1.Offset(x, y);
            Assert.AreEqual(new PointF(xe, ye), m1.Location);
        }
    }
}