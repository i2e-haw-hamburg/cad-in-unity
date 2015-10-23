using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using ThreeDXMLLoader.Implementation.Model;
using ThreeDXMLLoader.Implementation.Model.ModelInterna;

namespace ThreeDXMLLoader.Implementation.Parser
{
    internal class ParseReferenceRepUsecase
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


            referenceRep.Shell = GetShell(xmlElement, nameOfExternalRepFileDiscription, archive);

            return referenceRep;
        }

        private static Shell GetShell(XElement xmlElement, string nameOfExternalRepFileDiscription,
            IThreeDXMLArchive archive)
        {
            XDocument xmlReferenceRep;

            if (nameOfExternalRepFileDiscription != null && nameOfExternalRepFileDiscription.Any())
            {
                xmlReferenceRep = archive.GetNextDocument(ParseUtility.CleanUpFileName(nameOfExternalRepFileDiscription));
            }
            else
            {
                xmlReferenceRep = xmlElement.Document;
            }

            var verticies =
                ParseVerticesFromXml(GetVerticesInXmlFormat(xmlReferenceRep));

            var triangles = GetTrinalgesFromXml(xmlReferenceRep, verticies);

            return new Shell(triangles);
        }

        private static IList<Triangle> GetTrinalgesFromXml(XDocument xmlReferenceRep, IList<Vertex> verticies)
        {
            var mostAccurateFaceXmlElement = GetMostAccurateFaceXmlElement(xmlReferenceRep);

            // hier weiter!!!
            return new List<Triangle>();
        }

        private static XElement GetMostAccurateFaceXmlElement(XDocument xmlReferenceRep)
        {
            var xmlfaces = xmlReferenceRep.Descendants("{http://www.3ds.com/xsd/3DXML}Face");
            if (xmlfaces.ToList().Count == 0)
            {
                throw new ArgumentException("The given xml Document has no face tags, can not find any triangles.");
            }
            if (xmlfaces.ToList().Count == 1)
            {
                return xmlfaces.First();
            }
            XElement xmlFace = null;
            var smallestAccuracy = double.MaxValue;


            foreach (var pologonalLOD in xmlReferenceRep.Descendants("{http://www.3ds.com/xsd/3DXML}PolygonalLOD"))
            {
                //try
               // {
                var polyLODAccuracy = double.Parse(pologonalLOD.Attribute("accuracy").Value, CultureInfo.CreateSpecificCulture("en-US"));
                    if (polyLODAccuracy < smallestAccuracy)
                    {
                        smallestAccuracy = polyLODAccuracy; 
                        xmlFace = pologonalLOD.Descendants("{http://www.3ds.com/xsd/3DXML}Faces").Descendants("{http://www.3ds.com/xsd/3DXML}Face").First();
                       }
               // }
                //catch (FormatException ex)
               // {
                    //TODO log
                   // Console.Error.WriteLine(
                   //     "Something went wrong by parsing the PolygonalLOD accuracy attribut. Original exception: " +
                    //    ex);
             //   }
            }

            return xmlFace;
        }

        private static IList<Vertex> ParseVerticesFromXml(IList<XElement> xmlVertices)
        {
            IList<Vertex> vertices = new List<Vertex>();

            foreach (var xmlVertex in xmlVertices)
            {
                var positionXmlNode = xmlVertex.Element("{http://www.3ds.com/xsd/3DXML}Positions");

                //todo threaden 
                foreach (var cordinates in positionXmlNode.Value.Split(','))
                {
                    var coordinateAry = cordinates.Split(' ');
                    var x = double.Parse(coordinateAry[0]);
                    var y = double.Parse(coordinateAry[1]);
                    var z = double.Parse(coordinateAry[2]);

                    vertices.Add(new Vertex(x, y, z));
                }
            }

            return vertices;
        }

        private static IList<XElement> GetVerticesInXmlFormat(XDocument xmlElemt)
        {
            var vertices = new List<XElement>();

            vertices.AddRange(xmlElemt.Elements("{http://www.3ds.com/xsd/3DXML}VertexBuffer"));
            return vertices;
        }
    }
}