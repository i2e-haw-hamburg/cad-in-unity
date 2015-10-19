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
            
            //todo for testing purpose only remove later
            stream = new FileStream("C:\\HAW\\cad-in-unity\\3D xml example\\Quad.3dxml", FileMode.Open, FileAccess.Read);
            reader = XmlReader.Create(stream);
            reader.MoveToContent();
            xml = XDocument.Load(reader);



            var internalModel = new ThreeDXMLImplementation(ParseHelper.GetHeader(xml));
            internalModel.Fill3DRepresentation(ParseAssetRepresentation(xml, fileArchive));


            return internalModel.ToModel();
        }

        private IList<ThreeDRepFile> ParseAssetRepresentation(XDocument xml, IThreeDArchive fileArchive)
        {
           return  ParseHelper.Parse3DRepresentation(xml);
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