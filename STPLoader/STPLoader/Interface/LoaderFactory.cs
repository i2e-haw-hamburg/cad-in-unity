using System;
using System.IO;
using Microsoft.Win32.SafeHandles;
using STPLoader.Implementation.Loader;

namespace STPLoader
{
	public static class LoaderFactory
	{
		public static ILoader CreateFileLoader (string fileName)
		{
			return new FileLoader ();
		}

		public static ILoader CreateFileLoader (SafeFileHandle handle)
		{
			return new FileLoader ();
		}

		public static ILoader CreateStreamLoader(Stream stream)
		{

		}
	}
}

