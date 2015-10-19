using System.Collections.Generic;
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
            IThreeDArchive fileArchive = null;
            
            
            var reader = XmlReader.Create(stream);
            reader.MoveToContent();
            var xml = XDocument.Load(reader);
            reader.Close();


            xml = ReadManifest(xml, fileArchive);
                      

            var internalModel = new ThreeDXMLImplementation(ParseHelper.GetHeader(xml));
            internalModel.Fill3DRepresentation(ParseAssetRepresentation(xml, fileArchive));


            return internalModel.ToModel();
        }

        private IList<ReferenceRep> ParseAssetRepresentation(XDocument xml, IThreeDArchive archive)
        {
           return  ParseHelper.Parse3DRepresentation(xml, archive);
        }

        private XDocument ReadManifest(XDocument manifest, IThreeDArchive fileArchive)
        {
            return ParseHelper.ReadManifest(manifest, fileArchive);
        }

        public CADType CAD
        {
            get { return CADType.ThreeDXML; }
        }

      

    }
}