using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ThreeDXMLLoader.Implementation.Model;
using ThreeDXMLLoader.Implementation.Model.ModelInterna;

namespace ThreeDXMLLoader.Implementation.Parser
{
    class ParseReferenceRepUsecase
    {
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

            foreach (var xmlVertex in xmlVertices)
            {
                var positions = xmlVertex.Elements("{http://www.3ds.com/xsd/3DXML}Postion");
                
                //todo threaden for each position
                foreach (XElement position in positions)
                {
                    foreach (var VARIABLE in position.Value.Split(new Char[]{','}))
                    {
                        
                    }
                    //var coordinates = position.Split(new Char[]{' '});
                    //var x = double.Parse(coordinates[0]);
                    //var y = double.Parse(coordinates[1]);
                    //var z = double.Parse(coordinates[2]);
                       
                    //vertices.Add(new Vertex(x, y, z));
                }
            }
           
            return vertices;
        }

        private static IList<XElement> GetVerticesInXmlFormat(XElement xmlElemt, string externalRepFileName,
            IThreeDXMLArchive archive)
        {
            var vertices = new List<XElement>();
            if (xmlElemt.Descendants("VertexBuffer").Count() > 0)
            {
                vertices.AddRange(xmlElemt.Elements("{http://www.3ds.com/xsd/3DXML}VertexBuffer"));
            }

            if (externalRepFileName.Length > 0)
            {
                var externalRepFile = archive.GetNextDocument(ParseUtility.CleanUpFileNames(externalRepFileName));


                vertices.AddRange(externalRepFile.Root.Descendants("{http://www.3ds.com/xsd/3DXML}VertexBuffer"));
                return vertices;
            }

            return new List<XElement>();
        }
    }
}
