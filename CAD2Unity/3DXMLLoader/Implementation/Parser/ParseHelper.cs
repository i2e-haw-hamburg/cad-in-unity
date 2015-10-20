using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ThreeDXMLLoader.Implementation.Model;
using ThreeDXMLLoader.Implementation.Model.ModelInterna;

namespace ThreeDXMLLoader.Implementation.Parser
{
    /// <summary>
    /// </summary>
    internal static class ParseHelper
    {
        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetName(XDocument data)
        {
            var titleNode = data.XPathSelectElement("Model_3dxml");
            return titleNode.Value;
        }

        /// <summary>
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static Header GetHeader(XDocument xml)
        {
            var nsmgr = new XmlNamespaceManager(new NameTable());
            nsmgr.AddNamespace("3dxml", "http://www.3ds.com/xsd/3DXML");

            var header = new Header();

            var xmlHeader = xml.Root.Element("{http://www.3ds.com/xsd/3DXML}Header").Elements().ToList();

            foreach (var elem in xmlHeader)
            {
                switch (elem.Value.ToLower())
                {
                    case "title":
                        header.Name = elem.Value;
                        break;
                    case "author":
                        header.Author = elem.Value;
                        break;
                    case "schema":
                        header.Schema = elem.Value;
                        break;
                    case "schemaversion":
                        header.Schema = elem.Value;
                        break;
                    case "created":
                        try
                        {
                            if (elem.Name.LocalName == "Created") header.Created = DateTime.Parse(elem.Value);
                        }
                        catch (FormatException ex)
                        {
                            //TODO better handling for parsing exception
                            Console.Error.WriteLine(
                                "Was not able to translate the creation date {0} into a valid DateTime. Please check if the creation date is valid.",
                                elem.Value);
                        }
                        break;
                }
            }

            return header;
        }


        public static XDocument ReadManifest(IThreeDXMLArchive archiv)
        {
            var manifest = archiv.GetManifest();
            //check if the manifest contains the asset information, if the root element is not the manifest then load and return it.
            var rootElement = manifest.Root.Element("Root");

            if (rootElement != null && !rootElement.IsEmpty)
            {
                manifest = archiv.GetNextDocument(CleanUpFileNames(rootElement.Value));
            }

            return manifest;
        }

        public static IList<ReferenceRep> Parse3DRepresentation(XDocument xml, IThreeDXMLArchive archive)
        {
            IList<ReferenceRep> threeDRepresentations = new List<ReferenceRep>();

            var xmlReferenceReps = xml.Root.Descendants("{http://www.3ds.com/xsd/3DXML}ReferenceRep");

            if (
                xmlReferenceReps.All(
                    x => x.Attribute("format").Value.ToLower() == Supported3DRepFormats.Tessellated.ToString().ToLower()))
            {
                foreach (var rep in xmlReferenceReps)
                {
                    threeDRepresentations.Add(Parse3DTessellatedRepresentation(rep, archive));
                }
            }

            return threeDRepresentations;
        }

        private static ReferenceRep Parse3DTessellatedRepresentation(XElement xmlElement, IThreeDXMLArchive archive)
        {
            var nameOfExternalRepFileDiscription = "";
            var referenceRep = new ReferenceRep();
            foreach (var attribut in xmlElement.Attributes())
            {
                switch (attribut.Name.LocalName.ToLower())
                {
                    case "id":
                        referenceRep.Id = attribut.Value;
                        break;
                    case "name":
                        referenceRep.Name = attribut.Value;
                        break;
                    case "type":
                        referenceRep.ReferenceType = attribut.Value;
                        break;
                    case "version":
                        referenceRep.Version = attribut.Value;
                        break;
                    case "associatedfile":
                        nameOfExternalRepFileDiscription = attribut.Value;
                        break;
                    default:
                        break;
                }
            }
            var xmlVertices = GetVerticesInXmlFormat(xmlElement, nameOfExternalRepFileDiscription, archive);

            referenceRep.Vertices = ParseVerticesFromXml(xmlVertices);


            return referenceRep;
        }

        private static IList<Vertex> ParseVerticesFromXml(IList<XElement> xmlVertices)
        {
            IList<Vertex> vertices = new List<Vertex>();

          

            return vertices;
        }

        private static IList<XElement> GetVerticesInXmlFormat(XElement xmlElemt, string externalRepFileName,
            IThreeDXMLArchive archive)
        {
            var vertivertices = new List<XElement>();
            if (xmlElemt.Descendants("VertexBuffer").Count() > 0)
            {
                vertivertices.AddRange(xmlElemt.Elements("VertexBuffer"));
            }

            if (externalRepFileName.Length > 0)
            {
                var externalRepFile = archive.GetNextDocument(CleanUpFileNames(externalRepFileName));


                vertivertices.AddRange(externalRepFile.Root.Elements("VertexBuffer"));
                return vertivertices;
            }

            return new List<XElement>();
        }

        private static string CleanUpFileNames(string filename)
        {
            return filename.Split(":".ToCharArray()).Last();
        }
    }
}