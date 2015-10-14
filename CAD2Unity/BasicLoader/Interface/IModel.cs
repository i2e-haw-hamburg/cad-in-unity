using System.Collections;
using System.Collections.Generic;
using AForge.Math;
using BasicLoader.Interface;
using CADLoader.Implementation.Parser;

namespace BasicLoader
{
    public interface IModel
    {
        IList<IModel> Models { get; }
        IConstraint GetConstraint(IModel a, IModel b);

        IList<Facet> Facets { get; }
        IList<Vector3> Vertices { get; }
        IList<int> Triangles { get; }
        string Name { get; }
    }
}