using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using BasicLoader;
using BasicLoader.Implementation.Model;
using CADLoader;
using ThreeDXMLLoader.Implementation.Model;

namespace ThreeDXMLLoader.Implementation.Parser
{
    /// <summary>
    /// 
    /// </summary>
    class ThreeDXMLParser : IParser
    {
        public IModel Parse(Stream stream)
        {
            var reader = XmlReader.Create(stream);
            reader.MoveToContent();
            var xml = XDocument.Load(reader);
            var internalModel = new ThreeDXML(ParseHelper.GetHeader(xml));
            //var facets = ParseHelper.Facets(stream);

            return internalModel.ToModel();
        }

        public CADType CAD => CADType.ThreeDXML;
    }
}