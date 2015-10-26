using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AForge.Math;
using BasicLoader.Interface;

namespace ThreeDXMLLoader.Implementation.Model
{
    /// <summary>
    /// Implementation of a single part.
    /// </summary>
    class Part : IPart
    {
        public IList<Vector3> Vertices { get; private set; }
        public IList<int> Triangles { get; private set; }
        public string Name { get; set; }

        /// <summary>
        /// Creates a part from a give reference representation.
        /// </summary>
        /// <param name="rep">The reference representation of that part.</param>
        /// <returns>a new part object</returns>
        public static IPart FromReferenceRep(ReferenceRep rep)
        {
            var p = new Part();
            var triangles = rep.Shell.Triangles;
            p.Name = rep.Name;
            p.Vertices = triangles.SelectMany(x => new List<Vector3> {x.V1, x.V2, x.V3}).ToList();
            p.Triangles = Enumerable.Range(0, triangles.Count * 3).ToList();

            return p;
        }
    }
}