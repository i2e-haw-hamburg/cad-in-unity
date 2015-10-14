using System;
using System.IO;

namespace BasicLoader
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

