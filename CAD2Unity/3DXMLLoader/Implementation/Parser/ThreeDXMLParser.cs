using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using BasicLoader;
using BasicLoader.Implementation.Model;
using CADLoader;

namespace ThreeDXMLLoader.Implementation.Parser
{
    internal class ThreeDXMLParser : IParser
    {
        public IModel Parse(Stream stream)
        {
            var reader = XmlReader.Create(stream);
            reader.MoveToContent();
            var xml = XDocument.Load(reader);
            
            var name = ParseHelper.GetName(xml);
            //var facets = ParseHelper.Facets(stream);


            return new Model
            {
                //Facets = facets.ToList(),
                Name = name
            };
        }

        public CADType CAD => CADType.ThreeDXML;
    }
}