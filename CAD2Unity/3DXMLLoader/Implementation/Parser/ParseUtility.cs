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

        public static string CleanUpFileNames(string filename)
        {
            return filename.Split(":".ToCharArray()).Last();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> RootDescendants(XDocument document, string name)
        {
            return document.Root.Descendants("{http://www.3ds.com/xsd/3DXML}" + name);
        }

        /// <summary>
        /// 
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
            else
            {
                return defaultValue;
            }
        }
    }
}