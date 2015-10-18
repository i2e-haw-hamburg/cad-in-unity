using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ThreeDXMLLoader.Implementation.Model;

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
                if (elem.Name.LocalName == "Schema") header.Schema = elem.Value;
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
    }
}