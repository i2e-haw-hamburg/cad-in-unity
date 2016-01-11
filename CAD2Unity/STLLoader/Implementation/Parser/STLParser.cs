using System.IO;
using System.Linq;
using BasicLoader;
using BasicLoader.Implementation.Model;
using CADLoader;
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

        public IModel Parse(ILoader loader)
        {
            return Parse(loader.Load());
        }

        public CADType CAD
        {
            get { return CADType.STL; }
        }
    }
}