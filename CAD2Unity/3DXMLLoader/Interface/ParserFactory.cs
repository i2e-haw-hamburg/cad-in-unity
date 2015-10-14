using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicLoader;
using CADLoader;
using ThreeDXMLLoader.Implementation.Parser;

namespace ThreeDXMLLoader
{
    public static class ParserFactory
    {
        public static IParser Create()
        {
            return new ThreeDXMLLoader.Implementation.Parser.ThreeDXMLParser();
        }
    }
}
