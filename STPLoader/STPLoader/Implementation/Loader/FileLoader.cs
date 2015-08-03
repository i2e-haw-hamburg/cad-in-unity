using System;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace STPLoader.Implementation.Loader
{
	/// <summary>
	/// File loader.
	/// </summary>
	public class FileLoader : ILoader
	{
		private FileStream _fileStream;

		/// <summary>
		/// Initializes a new instance of the <see cref="STPLoader.Implementation.Loader.FileLoader"/> class.
		/// </summary>
		/// <param name="stream">Stream.</param>
		public FileLoader (FileStream stream)
		{
			_fileStream = stream;
		}

		#region ILoader implementation
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public Stream Load ()
		{
			return _fileStream;
		}

		#endregion
	}
}

