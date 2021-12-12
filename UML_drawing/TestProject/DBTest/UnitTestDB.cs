using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UML_Database_Library.BlackBox;
using UML_Database_Library.API;
using System.Data;

namespace TestProject
{
    public class UnitTestDB
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


        // ************   POSITIVE TEST ************  

        [Test]
        public void CreateAndCheckName_Tests()
        {
            ApiData obj = new ApiData();
            DeleteProject();
            var actual = obj.CreateProj("UnitTest");
            string expected = "UnitTest";

            Assert.AreEqual(expected, actual.nameproject);

        }

        [Test]
        public void CheckTypeCreateObject_Tests()
        {
            ApiData obj = new ApiData();
            DeleteProject();
            var actual = obj.CreateProj("UnitTest");
            var expected = new LiveData();

            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [Test]
        public void SaveProject_Tests()
        {   
            ApiData obj = new ApiData();
            DeleteProject();
            obj.CreateProj("UnitTest"); // создаем папку project и файл UnitTest.uml
            var component = new List<LiveDataElem> {new LiveDataElem()};
            var actual = obj.SaveProject("UnitTest", component);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LoadProjectCheckType_Tests()
        {
            ApiData obj = new ApiData();
            DeleteProject();
            obj.CreateProj("UnitTest"); // создаем папку project и файл UnitTest.uml
            var actual = obj.LoadProject("UnitTest");
            var expected = new LiveData();

            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [Test]
        public void LoadProjectCheckListCountElement_Tests()
        {   // поверяем сколько жлементов при загрузке файла, если сохранять например 2 LiveDataElem.
            ApiData obj = new ApiData();
            DeleteProject();
            obj.CreateProj("UnitTest"); // создаем папку project и файл UnitTest.uml
            var component = new List<LiveDataElem> { new LiveDataElem(), new LiveDataElem() };
            obj.SaveProject("UnitTest", component);

            var actual = obj.LoadProject("UnitTest");
            var expected = 2;

            Assert.AreEqual(expected, actual.ListObjectFigure.Count);
        }

        // ***********  NEGATIVE ****************

        [Test]
        public void SaveProject_NegativeTests()
        {
            DeleteProject();
            UML_Database_Library.API.ApiData obj = new UML_Database_Library.API.ApiData();
            LiveDataElem testelem = new LiveDataElem();
            List<LiveDataElem> list = new List<LiveDataElem>() {testelem};

            Assert.Throws<DirectoryNotFoundException>(() => obj.SaveProject("UnitTest", list));
        }

        [Test]
        public void LoadProject_NegativeTests()
        {
            DeleteProject();
            ApiData obj = new ApiData();

            Assert.Throws<DirectoryNotFoundException>(() => obj.LoadProject("UnitTest"));
        }

        [Test]
        public void CreateDublicate_NegativeTests()
        {
            ApiData obj = new ApiData();
            DeleteProject();
            obj.CreateProj("UnitTest");

            Assert.Throws<DuplicateNameException>(() => obj.CreateProj("UnitTest"));
        }
    }
}