using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CADLoader;

namespace STLLoader
{
    public static class ParserFactory
    {
        public static IParser Create()
        {
            return new STLParser();
        }
    }
}
