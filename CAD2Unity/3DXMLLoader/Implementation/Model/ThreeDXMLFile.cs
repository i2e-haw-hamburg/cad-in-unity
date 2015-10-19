using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Ionic.Zip;

namespace ThreeDXMLLoader.Implementation.Model
{
    /// <summary>
    /// In memory archive implementation for the IThreeDXMLArchive interface.
    /// </summary>
    class ThreeDXMLFile : IThreeDXMLArchive
    {
        private IDictionary<string, Stream> _files;
        private const string ManifestName = "Manifest.xml";

        private ThreeDXMLFile(IDictionary<string, Stream> files)
        {
            _files = files;
        }

        /// <summary>
        /// Creates a new in memory archive from a given stream of zipped data.
        /// </summary>
        /// <param name="data">the zip compressed 3dxml archive</param>
        /// <returns>a new instance of a ThreeDXMLFile</returns>
        public static IThreeDXMLArchive Create(Stream data)
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
            var archive = new ThreeDXMLFile(dict);
            data.Close();

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
            fileStream.Seek(0, SeekOrigin.Begin);
            var reader = XmlReader.Create(fileStream);
            reader.MoveToContent();
            return XDocument.Load(reader);
        }

        public IList<string> ContainedFiles => _files.Keys.ToList();
    }

    
}
