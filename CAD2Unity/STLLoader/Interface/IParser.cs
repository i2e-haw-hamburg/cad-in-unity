using System;
using System.IO;

namespace STLLoader
{
    /// <summary>
    /// I parser.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parse the specified stream.
        /// </summary>
        /// <param name="stream">Stream.</param>
        IModel Parse(Stream stream);
    }
}

