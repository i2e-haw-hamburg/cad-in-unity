using System;
using System.IO;
using STPLoader.Implementation.Model;

namespace STPLoader
{
	/// <summary>
	/// I parser.
	/// </summary>
	public interface IParser
	{
		/// <summary>
		/// Parse the specified stream.
		/// </summary>
		/// <param name="stream">Stream.</param>
		IStpModel Parse(Stream stream);
	}
}

