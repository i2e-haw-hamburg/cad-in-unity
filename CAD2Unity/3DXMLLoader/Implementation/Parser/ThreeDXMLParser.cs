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
        public IModel Parse(ILoader loader)
        {
            return Parse(loader.Load());
        }

        public IModel Parse(Stream stream)
        {
            var fileArchive = ThreeDXMLFile.Create(stream);
            var xmlManifest = ReadManifest(fileArchive);
            // create 3dxml model and fill it with data
            var internalModel = new ThreeDXMLImplementation(ParseUtility.GetHeader(xmlManifest))
            {
                ReferenceReps = ParseAssetRepresentation(xmlManifest, fileArchive),
                ThreeDReferences = ParseReference3D(xmlManifest),
                ThreeDInstances = ParseInstance3D(xmlManifest),
                InstanceReps = ParseInstanceRep(xmlManifest)
            };
            // return the model definition
            return internalModel.ToModel();
        }

        private IList<Reference3D> ParseReference3D(XDocument document)
        {
            return ParseUtility.RootDescendants(document, "Reference3D").Select(ParseReference3DUsecase.FromXDocument).ToList();
        }
        private IList<Instance3D> ParseInstance3D(XDocument document)
        {
            return ParseUtility.RootDescendants(document, "Instance3D").Select(ParseInstance3DUsecase.FromXDocument).ToList();
        }
        private IList<InstanceRep> ParseInstanceRep(XDocument document)
        {
            return ParseUtility.RootDescendants(document, "InstanceRep").Select(ParseInstanceRepUsecase.FromXDocument).ToList();
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