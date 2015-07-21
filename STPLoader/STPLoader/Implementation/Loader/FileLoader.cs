using System;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace STPLoader.Implementation.Loader
{
	public class FileLoader : ILoader
	{
		private FileStream _fileStream;

		public FileLoader (FileStream stream)
		{
			_fileStream = stream;
		}

		#region ILoader implementation

		public Stream Load ()
		{
			return _fileStream;
		}

		#endregion
	}
}

