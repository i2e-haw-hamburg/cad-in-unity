using System;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using STLLoader.Implementation.Model;
using STLLoader.Implementation.Parser;

namespace STLLoader
{
    internal class STLParser : IParser
    {
        public IModel Parse(Stream stream)
        {
            // check format
            // if ascii continue
            var body = ParseHelper.FindSection(stream, "solid CATIA STL", "endsolid CATIA STL");
            var facets = ParseHelper.Facets(stream);


            return new Model {Facets = facets.ToList()};
        }
    }
}