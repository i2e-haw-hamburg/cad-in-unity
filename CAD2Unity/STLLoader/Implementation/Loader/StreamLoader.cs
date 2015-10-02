using System;
using System.IO;

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
        /// Initializes a new instance of the <see cref="STPLoader.Implementation.Loader.StreamLoader"/> class.
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
        #endregion
    }
}

