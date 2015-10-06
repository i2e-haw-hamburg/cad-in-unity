using System;
using System.IO;
using CADLoader;
using Microsoft.Win32.SafeHandles;

namespace CADLoader.Implementation.Loader
{
    /// <summary>
    /// File loader.
    /// </summary>
    public class FileLoader : ILoader
    {
        private FileStream _fileStream;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLoader"/> class.
        /// </summary>
        /// <param name="stream">Stream.</param>
        public FileLoader(FileStream stream)
        {
            _fileStream = stream;
        }

        #region ILoader implementation
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Stream Load()
        {
            return _fileStream;
        }

        public void Close()
        {
            _fileStream.Close();
        }

        #endregion
    }
}

