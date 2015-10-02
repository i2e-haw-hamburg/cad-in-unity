using System;
using System.Globalization;
using NUnit.Framework;
using STPLoader.Implementation.Parser;

namespace STPLoaderTest
{
	[TestFixture]
	public class ParseHelperTest
	{
		[Test]
		public void ParseListEmpty ()
		{
		    var testString = "()";
		    var result = ParseHelper.ParseList<string>(testString);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("", result[0]);
		}

        [Test]
        public void ParseListSimple()
        {
            var testString = "(a,b,c)";
            var result = ParseHelper.ParseList<string>(testString);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("c", result[2]);
        }

        [Test]
        public void ParseListFloat()
        {
            var testString = "(1.3,4.1,0.)";
            var result = ParseHelper.ParseList<float>(testString);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1.3f, result[0]);
            Assert.AreEqual(0f, result[2]);
        }

	    [Test]
        public void ParseListWithList()
        {
            var testString = "('',(1.3,4.1,0.))";
            var result = ParseHelper.ParseList<string>(testString);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("''", result[0]);
	    }
	}
}

