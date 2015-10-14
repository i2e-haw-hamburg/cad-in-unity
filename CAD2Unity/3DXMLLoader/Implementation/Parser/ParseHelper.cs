using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using AForge.Math;
using CADLoader.Implementation.Parser;

namespace ThreeDXMLLoader.Implementation.Parser
{
    /// <summary>
    /// 
    /// </summary>
	public static class ParseHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetName(XDocument data)
        {
            var titleNode = data.XPathSelectElement("Model_3dxml");
            return titleNode.Value;
        }
        
       
        public static IEnumerable<Facet> Facets(Stream stream)
        {
            stream.Position = 0;
            var reader = new StreamReader(stream);
            var facets = new List<Facet>();
            Facet tmpFacet = null;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.StartsWith("facet"))
                {
                    // begins with facet
                    tmpFacet = new Facet
                    {
                        Normal = ParseVector(line.Substring(14))
                    };
                }
                else if (line.StartsWith("endfacet"))
                {
                    // begins with endfacet
                    facets.Add(tmpFacet);
                } else if (tmpFacet != null && line.StartsWith("vertex"))
                {
                    tmpFacet.Verticies.Add(ParseVector(line.Substring(8)));
                }
            }

            return facets;
        }

        private static Vector3 ParseVector(string vectorString)
        {
            var parts = vectorString.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            return new Vector3(
                float.Parse(parts[0], CultureInfo.InvariantCulture),
                float.Parse(parts[1], CultureInfo.InvariantCulture),
                float.Parse(parts[2], CultureInfo.InvariantCulture)
            );
        }
    }

}

