using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ThreeDXMLLoader.Implementation.Model;

namespace ThreeDXMLLoader.Implementation.Parser
{
    /// <summary>
    /// </summary>
    internal static class ParseUtility
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
        ///     Searches the given XDocument for header information and returns a Header object.
        ///     A Header object is holding the following information:
        ///     title(nullable),
        ///     author(nullable),
        ///     schema(nullable),
        ///     schemaversion,
        ///     created(nullable).
        /// </summary>
        /// <param name="xmlDocument">A xmlDocument document with a valid header.</param>
        /// <throws name="ArgumentException">if no header tag is found in the given document
        ///  a ArgumentException will be thrown.
        /// </throws>
        /// <returns></returns>
        public static Header GetHeader(XDocument xmlDocument)
        {
            var nsmgr = new XmlNamespaceManager(new NameTable());
            nsmgr.AddNamespace("3dxml", "http://www.3ds.com/xsd/3DXML");

            var header = new Header();

            var xmlHeader = xmlDocument.Root.Element("{http://www.3ds.com/xsd/3DXML}Header").Elements();

            if (xmlHeader == null)
            {
                throw new ArgumentException(@"The given XML file seems to hold no header information.
                                              Please make sure that you are using the correct XDocument.");
            }

            foreach (var elem in xmlHeader.ToList())
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

        /// <summary>
        /// Reads the manifest(the entry point for the 3Dxml parsing) and datamines where to start. 
        /// </summary>
        /// <param name="archive">The unziped file archive of the 3dxml model</param>
        /// <returns></returns>
        public static XDocument ReadManifest(IThreeDXMLArchive archiv)
        {
            var manifest = archiv.GetManifest();
            //check if the manifest contains the asset information, if the root element is not the manifest then load and return it.
            var rootElement = manifest.Root.Element("Root");

            if (rootElement != null && !rootElement.IsEmpty)
            {
                manifest = archiv.GetNextDocument(CleanUpFileName(rootElement.Value));
            }

            return manifest;
        }

        public static string CleanUpFileName(string filename)
        {
            return filename.Split(":".ToCharArray()).Last();
        }

        /// <summary>
        /// </summary>
        /// <param name="document"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> RootDescendants(XDocument document, string name)
        {
            return document.Root.Descendants("{http://www.3ds.com/xsd/3DXML}" + name);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <param name="mapping"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ValueOfDescendant<T>(XElement xElement, string name, Func<string, T> mapping, T defaultValue)
        {
            var element = xElement.Descendants().FirstOrDefault(x => x.Name.LocalName == name);
            if (element != null)
            {
                return mapping(element.Value);
            }
            return defaultValue;
        }
    }
}