using System;
using System.IO;
using System.Xml.Linq;
using BasicLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeDXMLLoader.Implementation.Model;

namespace ThreeDXMLLoaderTest
{
    [TestClass]
    public class ThreeDXMLFileTest
    {
        private Stream _stream;

        [TestInitialize]
        public void SetUp()
        {
            _stream = LoaderFactory.CreateFileLoader("quad.3dxml").Load();
        }

        [TestCleanup]
        public void TearDown()
        {
            _stream.Close();
        }

        [TestMethod]
        public void TestCreation()
        {
            var archive = ThreeDXMLFile.Create(_stream);
            Assert.IsInstanceOfType(archive, typeof(IThreeDXMLArchive));
        }

        [TestMethod]
        public void TestGetManifest()
        {
            var archive = ThreeDXMLFile.Create(_stream);
            var manifest = archive.GetManifest();

        }

        [TestMethod]
        public void TestGetNextDocument()
        {
            var archive = ThreeDXMLFile.Create(_stream);
            var document = archive.GetNextDocument("wheel.3drep");
            
            Assert.IsInstanceOfType(document, typeof(XDocument));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestFailGetNextDocument()
        {
            var archive = ThreeDXMLFile.Create(_stream);

            archive.GetNextDocument("error.3drep");
        }

        [TestMethod]
        public void TestListOfFiles()
        {
            var archive = ThreeDXMLFile.Create(_stream);
            var fileList = archive.ContainedFiles;

            Assert.AreEqual(17, fileList.Count);
            Assert.IsTrue(fileList.Contains("manifest.xml"));
            Assert.IsTrue(fileList.Contains("quad.3dxml"));
            Assert.IsTrue(fileList.Contains("wheel.3drep"));
        }
    }
}
