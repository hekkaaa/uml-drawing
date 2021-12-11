using NUnit.Framework;
using TestProject.LogicalTest.Mocks;
using UML_Database_Library.BlackBox;
using UML_Logic_Library;
using UML_Logic_Library.StructuralEntities;

namespace TestProject.LogicalTest
{
    [TestFixture]
    public class ComponentMapperTest
    {
        [TestCaseSource(typeof(ComponentMapperMock), nameof(ComponentMapperMock.FromLiveData))]
        public void FromLiveDataTest(LiveDataElem elem, Component component)
        {
            var result = elem.FromLiveData();
            var actual = ComponentMapperMock.EqualComponents(result, component);
            Assert.AreEqual(true, actual);
        }
        
        [TestCaseSource(typeof(ComponentMapperMock), nameof(ComponentMapperMock.FromLiveData))]
        public void ToLiveDataTest(LiveDataElem elem, Component component)
        {
            var result = component.ToLiveData();
            var actual = ComponentMapperMock.EqualLiveData(result, elem);
            Assert.AreEqual(true, actual);
        }
    }
}