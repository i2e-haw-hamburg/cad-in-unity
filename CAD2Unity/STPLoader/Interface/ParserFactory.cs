using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicLoader;
using CADLoader;
using STPLoader.Implementation.Parser;

namespace STPLoader
{
    public static class ParserFactory
    {
        public static IParser Create()
        {
            return new StpParser();
        }
    }
}
