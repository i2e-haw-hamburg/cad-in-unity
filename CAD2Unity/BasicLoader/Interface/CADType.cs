using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicLoader
{
    public enum CADType
    {
        STL,
        STP
    }

    public static class CADTypeUtils
    {
        private static IDictionary<string, CADType> map = new Dictionary<string, CADType>
        {
            {"stl", CADType.STL},
            {"stp", CADType.STP}
        };

        public static CADType FromFileExtension(string fileName)
        {
            var extension = fileName.Substring(fileName.LastIndexOf('.')+1);
            return map[extension.ToLower()];
        }
    }
}
