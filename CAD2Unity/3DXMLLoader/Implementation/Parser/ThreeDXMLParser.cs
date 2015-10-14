using System.IO;
using System.Linq;
using BasicLoader;
using BasicLoader.Implementation.Model;
using CADLoader;

namespace _3DXMLLoader.Implementation.Parser
{
    internal class ThreeDXMLParser : IParser
    {
        public IModel Parse(Stream stream)
        {
            // check format
            // if ascii continue
            var body = ParseHelper.FindSection(stream, "solid CATIA STL", "endsolid CATIA STL");
            var facets = ParseHelper.Facets(stream);


            return new Model {Facets = facets.ToList()};
        }

        public CADType CAD => CADType.ThreeDXML;
    }
}