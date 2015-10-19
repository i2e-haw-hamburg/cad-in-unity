using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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

        private ThreeDRepFile()
        {
            
        }

        public static IThreeDArchive Create(Stream data)
        {
            var archive = new ThreeDRepFile();
            using (var zipArchive = ZipFile.Read(data))
            {
                foreach (var entry in zipArchive)
                {
                    
                }
            }

            return archive;
        }

        public XDocument GetManifest()
        {
            throw new System.NotImplementedException();
        }

        public XDocument GetNextDocument(string name)
        {
            throw new System.NotImplementedException();
        }
    }

    
}
