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

            Header header = new Header();

            var xmlHeader = xml.Root.Element("{http://www.3ds.com/xsd/3DXML}Header").Elements().ToList();


            foreach (var elem in xmlHeader)
            {
                if (elem.Name.LocalName == "Title") header.Name = elem.Value;
                if (elem.Name.LocalName == "Author") header.Author = elem.Value;
                if (elem.Name.LocalName == "Schema" || elem.Name.LocalName == "SchemaVersion") header.Schema = elem.Value;
                try
                {
                    if (elem.Name.LocalName == "Created") header.Created = DateTime.Parse(elem.Value);
                }
                catch(FormatException ex)
                {
                    //TODO better handling for parsing exception
                    Console.Error.WriteLine(string.Format("Was not able to translate the creation date {0} into a valid DateTime. Please check if the creation date is valid.", elem.Value));
                }
            
            }

            return header;
        }


        public static XDocument ReadManifest(XDocument manifest, IThreeDArchiv archiv)
        {

            var mainfile = manifest;
            //check if the manifest contains the asset information, if the root element is not the manifest then load and return it.
            var rootElement = manifest.Root.Element("Root");

            if (rootElement != null && !rootElement.IsEmpty)
            {
              mainfile =  archiv.GetNextDocument(rootElement.Value);
            }

            return mainfile;

        }

        public static IList<ThreeDRepFile> Parse3DRepresentation(XDocument xml)
        {
            IList<ThreeDRepFile> threeDrepresentations = new List<ThreeDRepFile>();

            var xmlReferenceReps = xml.Root.Elements("{http://www.3ds.com/xsd/3DXML}ReferenceRep");

            if (xmlReferenceReps.All(x => x.Attribute("format").Name.LocalName == Supported3DRepFormats.Tessellated.ToString()))
            {
                threeDrepresentations.Add(Parse3DTessellatedRepresentation(xml));
            }


            return threeDrepresentations;

        }

        private static ThreeDRepFile Parse3DTessellatedRepresentation(XDocument xml)
        {
            throw new NotImplementedException();
        }
    }
}