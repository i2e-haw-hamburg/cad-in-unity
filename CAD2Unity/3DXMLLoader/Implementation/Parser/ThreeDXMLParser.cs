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
            var fileArchive = ThreeDXMLFile.Create(stream);
         
           var xmlManifest = ReadManifest(fileArchive);
                      

            var internalModel = new ThreeDXMLImplementation(ParseHelper.GetHeader(xmlManifest));
            internalModel.Fill3DRepresentation(ParseAssetRepresentation(xmlManifest, fileArchive));


            return internalModel.ToModel();
        }

        private IList<ReferenceRep> ParseAssetRepresentation(XDocument xml, IThreeDXMLArchive archive)
        {
           return  ParseHelper.Parse3DRepresentation(xml, archive);
        }

        private XDocument ReadManifest(IThreeDXMLArchive fileArchive)
        {
            return ParseHelper.ReadManifest(fileArchive);
        }

        public CADType CAD
        {
            get { return CADType.ThreeDXML; }
        }

      

    }
}