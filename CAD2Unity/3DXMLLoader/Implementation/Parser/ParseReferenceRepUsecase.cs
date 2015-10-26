using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using AForge.Math;
using ThreeDXMLLoader.Implementation.Model;
using ThreeDXMLLoader.Implementation.Model.ModelInterna;
using ThreeDXMLLoader.Interface.Exception;

namespace ThreeDXMLLoader.Implementation.Parser
{
    internal class ParseReferenceRepUsecase
    {
        /// <summary>
        ///     The main entrance point for parsing a 3Dreferencerep. The current supported representation is "Tessellated".
        /// </summary>
        /// <param name="xml">the xml manifest of the 3dxml model</param>
        /// <param name="archive">The unziped file archive of the 3dxml model</param>
        /// <throw name="FormatNotSupportedException">
        ///     If the 3DReferenceRep is in a not supported representation this Eception will
        ///     be thrown.
        /// </throw>
        /// <throw name="ArgumentException">
        ///     If the given XDocument does not hold any information about 3DReferenceReps this
        ///     exception will be thrown.
        /// </throw>
        /// <returns>
        ///     A list of ReferenceRep objects, with shell informaton, Id, Referencetype and other fields: Name, Version, Usage.
        ///     Note that the other fields can be empty or null.
        /// </returns>
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
            else
            {
                var format = xmlReferenceReps.Descendants("ReferenceRep").First().Attribute("format").Value;
                if (format.Length <= 0)
                    throw new ArgumentException(
                        "The given file does not hold any information about Reference3DReps, please make sure the file archive is valid.");

                throw new FormatNotSupportedException(string.Format(
                    @"The importer cant understand the given 3DReferenceRep format {0}.
                                                    Try using a representation with a supported format or contact the developers."
                    , format));
            }

            return threeDRepresentations;
        }


        /// <summary>
        ///     This methods is the main entry point for 3DReferenceReps in the Tessellated format.
        ///     If the Rep has LOD information the most accurate mesh will be parsed the rest will be droped.
        /// </summary>
        /// <param name="threeDReferenceRepXmlElement">The 3DReferenceRep xml representation with all attributes and sup nodes</param>
        /// <param name="archive">The unziped file archive of the 3dxml model</param>
        /// <returns>
        ///     A ReferenceRep objects, with shell informaton, Id, Referencetype and other fields: Name, Version, Usage.
        ///     Note that the other fields can be empty or null.
        /// </returns>
        private static ReferenceRep Parse3DTessellatedRepresentation(XElement threeDReferenceRepXmlElement,
            IThreeDXMLArchive archive)
        {
            var nameOfExternalRepFileDiscription = "";
            var referenceRep = new ReferenceRep();
            foreach (var attribut in threeDReferenceRepXmlElement.Attributes())
            {
                switch (attribut.Name.LocalName.ToLower())
                {
                    case "id":
                        referenceRep.Id = Convert.ToInt32(attribut.Value);
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


            referenceRep.Shell = GetShell(threeDReferenceRepXmlElement, nameOfExternalRepFileDiscription, archive);

            return referenceRep;
        }

        /// <summary>
        ///     Parses the shell information for a 3DReferenceRep out of the xml document into the internal representation.
        ///     the methods opens external 3DReferenceRep files automatically.
        /// </summary>
        /// <param name="threeDReferenceRepXmlElement">The 3DReferenceRep xml representation with all attributes and sup nodes</param>
        /// <param name="nameOfExternalRepFileDiscription">
        ///     name of the external 3DReferenceRep xml file, is empty if the
        ///     representation is in the same file.
        /// </param>
        /// <param name="archive">The unziped file archive of the 3dxml model</param>
        /// <returns>A Shell of a Mesh, which is holding the trinagular information.</returns>
        private static Shell GetShell(XElement threeDReferenceRepXmlElement, string nameOfExternalRepFileDiscription,
            IThreeDXMLArchive archive)
        {
            XDocument xmlReferenceRep;

            if (nameOfExternalRepFileDiscription != null && nameOfExternalRepFileDiscription.Any())
            {
                xmlReferenceRep = archive.GetNextDocument(ParseUtility.CleanUpFileName(nameOfExternalRepFileDiscription));
            }
            else
            {
                xmlReferenceRep = threeDReferenceRepXmlElement.Document;
            }

            var verticies =
                GetVerticesFromXml(xmlReferenceRep);

            var triangles = GetTrinalgesFromXml(xmlReferenceRep, verticies);

            return new Shell(triangles);
        }

        /// <summary>
        ///     Parsing each triangle of the 3DReferenceRep Shell. The triangles, in the xml document, are consistent of vertice
        ///     references,
        ///     which are describing a dot in a counterclockwise coordination system.
        /// </summary>
        /// <param name="threeDReferenceRepXmlElement">The 3DReferenceRep xml representation with all attributes and sup nodes</param>
        /// <param name="verticies">List of dots in a 3D counterclockwise coordination system.</param>
        /// <returns>List of tringales. A trinagle has 3 vertex references, which represents the edges.</returns>
        private static IList<Triangle> GetTrinalgesFromXml(XDocument threeDReferenceRepXmlElement,
            IList<Vertex> verticies)
        {
            var triangles = new List<Triangle>();

            var mostAccurateFaceXmlElement = GetMostAccurateFaceXmlElement(threeDReferenceRepXmlElement);
            var triangleStringAry = mostAccurateFaceXmlElement.Attribute("triangles").Value.Split(' ');

            for (var i = 0; i < triangleStringAry.Length; i += 3)
            {
                triangles.Add(new Triangle(verticies[i], verticies[i + 1], verticies[i + 2]));
            }

            return triangles;
        }

        /// <summary>
        ///     Searches the 3DReferenceRep xml document for the face tag. The face-xml-tag connects the edge of a triangle with a
        ///     vertex point.
        ///     If the face supports LOD the most accurate face will be parsed. The other LOD information are dropped.
        /// </summary>
        /// <param name="threeDReferenceRepXmlElement">The 3DReferenceRep xml representation with all attributes and sup nodes</param>
        /// <returns>Xml Representation of the most accurate face tag</returns>
        private static XElement GetMostAccurateFaceXmlElement(XDocument threeDReferenceRepXmlElement)
        {
            var xmlfaces = threeDReferenceRepXmlElement.Descendants("{http://www.3ds.com/xsd/3DXML}Face");
            if (xmlfaces.ToList().Count == 0)
            {
                throw new ArgumentException("The given xml Document has no face tags, can not find any triangles.");
            }
            if (xmlfaces.ToList().Count == 1)
            {
                return xmlfaces.First();
            }


            XElement xmlFace = null;
            var largestAccuracy = double.MinValue;


            foreach (
                var pologonalLOD in
                    threeDReferenceRepXmlElement.Descendants("{http://www.3ds.com/xsd/3DXML}PolygonalLOD"))
            {
                try
                {
                    var polyLODAccuracy = double.Parse(pologonalLOD.Attribute("accuracy").Value,
                        CultureInfo.CreateSpecificCulture("en-US"));
                    if (polyLODAccuracy > largestAccuracy)
                    {
                        largestAccuracy = polyLODAccuracy;
                        xmlFace =
                            pologonalLOD.Descendants("{http://www.3ds.com/xsd/3DXML}Faces")
                                .Descendants("{http://www.3ds.com/xsd/3DXML}Face")
                                .First();
                    }
                }
                catch (FormatException ex)
                {
                    //TODO log
                    Console.Error.WriteLine(
                        "Something went wrong by parsing the PolygonalLOD accuracy attribut. Original exception: " +
                        ex);
                }
            }

            return xmlFace;
        }


        /// <summary>
        /// Parses vertices from the xmmlReference xml document. In order to do that the vertexBuffer will ne parsed. 
        /// If the document has more than one vertexBuffer the biggest one will be parsed. In case LOD Information are stored in the
        /// xml referenceRep this case is important. 
        /// </summary>
        /// <param name="xmlReferenceRep"></param>
        /// <returns>List of Verticies </returns>
        private static IList<Vertex> GetVerticesFromXml(XDocument xmlReferenceRep)
        {
            var vertexPositionsXml = xmlReferenceRep.Descendants("{http://www.3ds.com/xsd/3DXML}Positions");
            var vertexPostionXml = vertexPositionsXml.OrderBy(x => x.Value.Length).First();

            var vertices = new List<Vector3>();

            foreach (var cordinates in vertexPostionXml.Value.Split(','))
            {
                var coordinateAry = cordinates.Split(' ');
                var x = float.Parse(coordinateAry[0]);
                var y = float.Parse(coordinateAry[1]);
                var z = float.Parse(coordinateAry[2]);

                vertices.Add(new Vector3(x, y, z));
            }

            if (vertices.Count == 0)
            {
                throw new FormatException(
                    @"No Positions where found in the given XML document. 
                    Please make sure the given document discribes a ReferenceRep in 
                     the tessellated format. The docment is holding the following context" +
                    xmlReferenceRep);
            }


            return vertices;
        }
    }
}