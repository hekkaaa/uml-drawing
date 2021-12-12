using NUnit.Framework;
using System.IO;
using UML_Logic_Library.AdditionalClasses;

namespace TestProject
{
    public class Handler_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        void DeleteProject()
        {  // удаляет папку "project" на дефолтном пути теста.
            var res = Directory.GetDirectories(Directory.GetCurrentDirectory(), "project");
            if (res.Length > 0)
            {
                Directory.Delete($@"{Directory.GetCurrentDirectory()}\project\", true);
            };
        }

        [Test]
        public void LoadProjectCheckType_Tests()
        {
            Handler obj = new Handler();
            DeleteProject();
            obj.CreateProj("UnitTest"); // создаем папку project и файл UnitTest.uml
            var actual = obj.LoadProject("UnitTest");
            var expected = new Handler();

            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [Test]
        public void SaveProjectCheckCreate_Tests()
        {
            Handler obj = new Handler();
            DeleteProject();
            obj.CreateProj("UnitTest"); // создаем папку project и файл UnitTest.uml
            var actual = obj.SaveProject("UnitTest", obj.ComponentsInProj);
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        // ***********  NEGATIVE ****************

        [Test]
        public void SaveProjectCheckDirectory_Tests()
        {
            Handler obj = new Handler();
            DeleteProject();
            //obj.CreateProj("UnitTest"); // создаем папку project и файл UnitTest.uml

            Assert.Throws<DirectoryNotFoundException>(() => obj.SaveProject("UnitTest", obj.ComponentsInProj));
        }
    }
}