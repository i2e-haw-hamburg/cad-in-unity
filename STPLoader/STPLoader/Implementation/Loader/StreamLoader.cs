using System;
using System.IO;

namespace STPLoader.Implementation.Loader
{
	/// <summary>
	/// Stream loader.
	/// </summary>
	public class StreamLoader : ILoader
	{
		private Stream _stream;
		/// <summary>
		/// Initializes a new instance of the <see cref="STPLoader.Implementation.Loader.StreamLoader"/> class.
		/// </summary>
		/// <param name="stream">Stream.</param>
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

