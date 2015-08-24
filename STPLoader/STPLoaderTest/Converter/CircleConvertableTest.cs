using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Math;
using NUnit.Framework;
using STPConverter.Implementation.Entity;
using STPLoader;
using STPLoader.Implementation.Model;
using STPLoader.Implementation.Model.Entity;
using STPLoader.Implementation.Parser;

namespace STPLoaderTest.Converter
{

    [TestFixture]
    class CircleConvertableTest
    {
        private Circle _circle;
        private IStpModel _model;

        [SetUp]
        public void SetUp()
        {
            var data = TestData.Content;
            _model = new StpParser().Parse(new MemoryStream(Encoding.UTF8.GetBytes(data)));
        }

        [Test]
        public void TestCircleCenter()
        {
            var circle = _model.Get<Circle>(98);
            var convertable = new CircleConvertable(circle, _model);
            Assert.AreEqual(new Vector3(70.0f,3.70814490225E-014f,-53.0f), convertable.Points[0]);
        }

        [Test]
        public void TestCirclePoints()
        {
            var circle = _model.Get<Circle>(98);
            var convertable = new CircleConvertable(circle, _model);
            var r = 3.3235f;
            //Assert.AreEqual(new Vector3(70f + r, 3.626745E-14f, -53.0f), convertable.Points[1]);
            Assert.AreEqual(new Vector3(70f, 3.70814490225E-014f - r, -53.0f), convertable.Points[2]);
            //Assert.AreEqual(new Vector3(70f - r, 3.70814490225E-014f, -53.0f), convertable.Points[3]);
            Assert.AreEqual(new Vector3(70f, 3.70814490225E-014f + r, -53.0f), convertable.Points[4]);
        }


        [Test]
        public void TestCircleIndices()
        {
            var circle = _model.Get<Circle>(98);
            var convertable = new CircleConvertable(circle, _model);
            Assert.AreEqual(new List<int> { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 1 }, convertable.Indices);
        }



    }
}
