using System.Collections.Generic;
using AForge.Math;
using STLLoader.Implementation.Parser;

namespace STLLoader
{
    public interface IModel
    {
        IList<Facet> Facets { get; }

        IList<Vector3> Vertices();
        IList<int> Triangles();
    }
}