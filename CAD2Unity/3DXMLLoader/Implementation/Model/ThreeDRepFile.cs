using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Ionic.Zip;

namespace ThreeDXMLLoader.Implementation.Model
{
    /// <summary>
    /// In memory archive implementation for the IThreeDArchive interface.
    /// </summary>
    class ThreeDRepFile : IThreeDArchive
    {
        private IDictionary<string, Stream> _files;
        private const string ManifestName = "Manifest.xml";

        private ThreeDRepFile(IDictionary<string, Stream> files)
        {
            _files = files;
        }

        /// <summary>
        /// Creates a new in memory archive from a given stream of zipped data.
        /// </summary>
        /// <param name="data">the zip compressed 3dxml archive</param>
        /// <returns>a new instance of a ThreeDRepFile</returns>
        public static IThreeDArchive Create(Stream data)
        {
            var dict = new Dictionary<string, Stream>();
            using (var zipArchive = ZipFile.Read(data))
            {
                foreach (var entry in zipArchive.Where(entry => !entry.IsDirectory))
                {
                    var name = entry.FileName.ToLower();
                    var fileStream = new MemoryStream();
                    entry.Extract(fileStream);
                    dict.Add(name, fileStream);
                }
            }
            var archive = new ThreeDRepFile(dict);

            return archive;
        }

        public XDocument GetManifest()
        {
            return GetNextDocument(ManifestName);
        }

        public XDocument GetNextDocument(string name)
        {
            name = name.ToLower();
            if (!_files.ContainsKey(name))
            {
                throw new Exception(@"File {name} not found in archive.");
            }
            var fileStream = _files[name];
            var reader = XmlReader.Create(fileStream);
            reader.MoveToContent();
            return XDocument.Load(reader);
        }
    }

    
}
