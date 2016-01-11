using System;
using System.IO;
using System.Xml.Linq;
using BasicLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeDXMLLoader.Implementation.Model;
using ThreeDXMLLoader.Implementation.Parser;

namespace ThreeDXMLLoaderTest
{
    [TestClass]
    public class ParseInstance3DUsecaseTest
    {
        
        [TestMethod]
        public void TestParseList()
        {
            var s =
                "-0.999727308394535 0.00599923048831989 -0.0225680766530022 -0.00596384174772193 -0.999980879390697 -0.0016350671704951 -0.0225774542824454 -0.00150002886369454 0.999743971460487 50.4442023383658 420.198951706047 -27.7739307759604";
            var list = ParseInstance3DUsecase.ParseList(s);
            Assert.AreEqual(-0.999727308394535, list[0]);
            Assert.AreEqual(0.00599923048831989, list[1]);
            Assert.AreEqual(-0.0225680766530022, list[2]);
            Assert.AreEqual(-0.00596384174772193, list[3]);
        }
        
    }
}
