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
            // create 3dxml model and fill it with data
            var internalModel = new ThreeDXMLImplementation(ParseUtility.GetHeader(xmlManifest));
            internalModel.Fill3DRepresentation(ParseAssetRepresentation(xmlManifest, fileArchive));
            internalModel.ThreeDReferences = ParseReference3D(xmlManifest);
            // return the model definition
            return internalModel.ToModel();
        }

        private IList<Reference3D> ParseReference3D(XDocument xmlManifest)
        {
            return xmlManifest.Root.Descendants("{http://www.3ds.com/xsd/3DXML}Reference3D").Select(Reference3D.FromXDocument).ToList();
        }

        private IList<ReferenceRep> ParseAssetRepresentation(XDocument xml, IThreeDXMLArchive archive)
        {
           return  ParseReferenceRepUsecase.Parse3DRepresentation(xml, archive);
        }

        private XDocument ReadManifest(IThreeDXMLArchive fileArchive)
        {
            return ParseUtility.ReadManifest(fileArchive);
        }

        public CADType CAD
        {
            get { return CADType.ThreeDXML; }
        }

      

    }
}