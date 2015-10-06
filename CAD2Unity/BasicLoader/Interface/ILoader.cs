using System;
using System.IO;

namespace CADLoader
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILoader
    {
        /// <summary>
        /// Load this instance.
        /// </summary>
        /// <returns></returns>
        Stream Load();
        /// <summary>
        /// 
        /// </summary>
        void Close();
    }
}

