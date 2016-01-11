using System;
using System.IO;
using BasicLoader.Implementation.Loader;
using Microsoft.Win32.SafeHandles;

namespace BasicLoader
{
	/// <summary>
	/// Loader factory.
	/// </summary>
	public static class LoaderFactory
	{
		/// <summary>
		/// Creates the file loader.
		/// </summary>
		/// <returns>The file loader.</returns>
		/// <param name="fileName">File name.</param>
		/// <returns></returns>
		public static ILoader CreateFileLoader (string fileName)
		{
			return new FileLoader (new FileStream(fileName, FileMode.Open));
		}
		/// <summary>
		/// Creates the file loader.
		/// </summary>
		/// <returns>The file loader.</returns>
		/// <param name="handle">Handle.</param>
		/// <returns></returns>
		public static ILoader CreateFileLoader (SafeFileHandle handle)
		{
			return new FileLoader (new FileStream(handle, FileAccess.Read));
		}
		/// <summary>
		/// Creates the stream loader.
		/// </summary>
		/// <returns>The stream loader.</returns>
		/// <param name="stream">Stream.</param>
		/// <returns></returns>
		public static ILoader CreateStreamLoader(Stream stream)
		{
			return new StreamLoader (stream);
		}
	}
}

