using System.Collections.Generic;
using System.Drawing;
using UML_Logic_Library.AdditionalClasses;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.Markers;
using UML_Logic_Library.StructuralEntities;

namespace TestProject.LogicalTest.Mocks
{
    public class ControlMock
    {
        public List<Marker> Markers;
        public Arrows Arrow { get; set; }= new Arrows(ArrowsTypes.RealizationArrow)
        {
            From = new RectangleComponent() {Location = new PointF(30, 30)},
            To = new RectangleComponent() {Location = new PointF(130, 130)}
        };

        private static Handler _hand = new Handler();
        
        public void CreateMarkers()
        {
            _hand.ComponentsInProj.Add(Arrow.From);
            _hand.ComponentsInProj.Add(Arrow.To);
            Markers = new List<Marker>();
            
                foreach (Marker m in Arrow.GetMarkers(_hand))
                    Markers.Add(m);
                UpdateMarkers();
        }

        private void UpdateMarkers()
        {
            foreach (var m in Markers)
            {
                m.UpdateLocation();
            }
        }
        
    }
}