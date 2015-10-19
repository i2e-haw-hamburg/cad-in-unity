using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ThreeDXMLLoader.Implementation.Model
{
    /// <summary>
    /// Interface for working with 3DXML archive.
    /// </summary>
    interface IThreeDXMLArchive
    {
        /// <summary>
        /// Returns the manifest file of the archive.
        /// </summary>
        /// <returns>the manifest as XDocument</returns>
        XDocument GetManifest();

        /// <summary>
        /// Returns a document with the specified name from the archive.
        /// </summary>
        /// <param name="name">The name of the requested document</param>
        /// <returns>the requested document as XDocument</returns>
        /// <exception cref="Exception">Thrown when file with <paramref name="name"/> was not found in archive.</exception>
        XDocument GetNextDocument(string name);

        /// <summary>
        /// Get a list with the names of all files in the archive. The names are in lower case.
        /// </summary>
        IList<string> ContainedFiles { get; }
    }
}