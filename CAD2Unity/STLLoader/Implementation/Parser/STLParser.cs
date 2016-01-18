using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
using AForge.Math;
using BasicLoader;
using BasicLoader.Implementation.Model;
using BasicLoader.Interface;
using CADLoader;
using STLLoader.Implementation.Parser;

namespace STLLoader
{
    internal class STLParser : IParser
    {
        public IModel Parse(Stream stream)
        {
            // check format
            // if ascii continue
            var body = ParseHelper.FindSection(stream, "solid CATIA STL", "endsolid CATIA STL");
            var facets = ParseHelper.Facets(stream);
            var part = new Part
            {
                Triangles = Enumerable.Range(0, facets.Count()*3).ToList(),
                Vertices = facets.SelectMany(x => x.Verticies.ToArray()).ToList()
            };
            return new Model
            {
                Parts = new List<IPart> { part}
            };
        }

        public IModel Parse(ILoader loader)
        {
            return Parse(loader.Load());
        }

        public CADType CAD
        {
            get { return CADType.STL; }
        }
    }

    internal class Part : IPart
    {
        public IList<Vector3> Vertices { get; set; }
        public IList<int> Triangles { get; set; }
        public string Name { get; }
        public Vector4 Rotation { get; set; }
        public Vector3 Position { get; set; }
    }
}