using System;
using System.Linq;
using BasicLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThreeDXMLLoaderTest.Functional_Tests
{
    [TestClass]
    public class ThreeDXMLTest
    {
        private IParser _parser;
        private ILoader _loader;

        [TestInitialize]
        public void Setup()
        {
            _parser = ThreeDXMLLoader.ParserFactory.Create();
            _loader = BasicLoader.LoaderFactory.CreateFileLoader("quad.3dxml");
        }

        [TestMethod]
        public void TestCountOfParts()
        {
            var model = _parser.Parse(_loader);
            // 4 wheels, 2 axles, 1 chassis, 1 steer wheel
            Assert.AreEqual(8, model.Parts.Count);
        }
        
        [TestMethod]
        public void TestWheelsShouldHaveDifferentPosition()
        {
            var model = _parser.Parse(_loader);
            var wheels = model.Parts.Where(p => p.Name == "Wheel_ReferenceRep");
            Assert.AreEqual(4, wheels.Count());
            var wheelA = wheels.ElementAt(0);
            var wheelB = wheels.ElementAt(1);
            Assert.AreNotEqual(wheelA.Position, wheelB.Position);
        }
    }
}
