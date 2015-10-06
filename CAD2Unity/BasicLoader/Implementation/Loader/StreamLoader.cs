using System;
using System.IO;
using CADLoader;

namespace STLLoader.Implementation.Loader
{
    /// <summary>
    /// Stream loader.
    /// </summary>
    public class StreamLoader : ILoader
    {
        /// <summary>
        /// 
        /// </summary>
		private Stream _stream;
        /// <summary>
        /// Initializes a new instance of the <see cref="StreamLoader"/> class.
        /// </summary>
        /// <param name="stream">Stream.</param>
        public StreamLoader(Stream stream)
        {
            _stream = stream;
        }

        #region ILoader implementation
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Stream Load()
        {
            return _stream;
        }

        public void Close()
        {
            _stream.Close();
        }
        #endregion
    }
}

