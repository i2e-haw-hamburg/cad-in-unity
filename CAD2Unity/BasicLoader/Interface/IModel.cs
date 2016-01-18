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
        IList<IPart> Parts { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        IConstraint GetConstraint(IModel a, IModel b);
        
        string Name { get; }
    }
}