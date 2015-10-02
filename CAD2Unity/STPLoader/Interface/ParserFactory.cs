using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STPLoader.Implementation.Parser;

namespace STPLoader.Interface
{
    public static class ParserFactory
    {
        public static IParser Create()
        {
            return new StpParser();
        }
    }
}
