using System;
using System.Collections.Generic;
using System.IO;
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
                catch(FormatException ex)
                {
                    //TODO better handling for parsing exception
                    Console.Error.WriteLine(string.Format("Was not able to translate the creation date {0} into a valid DateTime. Please check if the creation date is valid.", elem.Value));
                }
                        break;
                }
                
            }

            return header;
        }


        public static XDocument ReadManifest(XDocument manifest, IThreeDArchive archiv)
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

        public static IList<ReferenceRep> Parse3DRepresentation(XDocument xml, IThreeDArchive archive)
        {
            IList<ReferenceRep> threeDRepresentations = new List<ReferenceRep>();

            var xmlReferenceReps = xml.Root.Descendants("{http://www.3ds.com/xsd/3DXML}ReferenceRep");
        
            if (xmlReferenceReps.All(x => x.Attribute("format").Value.ToLower() == Supported3DRepFormats.Tessellated.ToString().ToLower()))
            {
                foreach (var rep in xmlReferenceReps)
                {
                    threeDRepresentations.Add(Parse3DTessellatedRepresentation(rep, archive));
                }
                
            }

            return threeDRepresentations;

        }

        private static ReferenceRep Parse3DTessellatedRepresentation(XElement xmlElement, IThreeDArchive archive)
        {
            string nameOfExternalRepFileDiscription = "";
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
            IList<XElement> xmlFaces = GetFacesInXMLFormat(xmlElement ,nameOfExternalRepFileDiscription, archive);

            return referenceRep;
        }

        private static IList<XElement> GetFacesInXMLFormat(XElement xmlElemt, string externalRepFileName, IThreeDArchive archive)
        {
            if (xmlElemt.Descendants("Faces").LongCount() > 0)
            {
                //TODO write internal case soon
                throw new NotImplementedException("cant handle all the faces in internal file right now!!!");
            }
            
            if (externalRepFileName.Length > 0)
            {
                var externalRepFile = archive.GetNextDocument(externalRepFileName);
               
             
                //todo hier weiter implementieren
                var faces = externalRepFile.Root.Elements("Faces");
                return faces.ToList();


            }

            return new List<XElement>();

        }
    }
}