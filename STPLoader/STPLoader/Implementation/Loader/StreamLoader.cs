using System;
using System.IO;

namespace STPLoader.Implementation.Loader
{
	public class StreamLoader : ILoader
	{
		private Stream _stream;

		public StreamLoader (Stream stream)
		{
			_stream = stream;
		}

		#region ILoader implementation
		public Stream Load ()
		{
			return _stream;
		}
		#endregion
	}
}

