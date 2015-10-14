using System;
using System.IO;
using BasicLoader;

namespace BasicLoader
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

        CADType CAD { get; }
    }
}

