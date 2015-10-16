using System.Collections;
using System.Collections.Generic;
using AForge.Math;
using BasicLoader.Interface;
using CADLoader.Implementation.Parser;

namespace BasicLoader
{
    /// <summary>
    /// 
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// 
        /// </summary>
        IList<IModel> Models { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        IConstraint GetConstraint(IModel a, IModel b);
        /// <summary>
        /// 
        /// </summary>
        IList<Facet> Facets { get; }
        /// <summary>
        /// 
        /// </summary>
        IList<Vector3> Vertices { get; }
        /// <summary>
        /// 
        /// </summary>
        IList<int> Triangles { get; }
        /// <summary>
        /// 
        /// </summary>
        string Name { get; }
    }
}