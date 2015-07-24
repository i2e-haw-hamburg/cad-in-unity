using System;
using System.IO;

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

