using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CADLoader;
using _3DXMLLoader.Implementation.Parser;

namespace _3DXMLParser
{
    public static class ParserFactory
    {
        public static IParser Create()
        {
            return new ThreeDXMLParser();
        }
    }
}
