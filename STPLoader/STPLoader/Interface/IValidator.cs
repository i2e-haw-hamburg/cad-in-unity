using System;
using System.IO;

namespace STPLoader
{
	/// <summary>
	/// I validator.
	/// </summary>
	public interface IValidator
	{
		/// <summary>
		/// Validate the specified stream.
		/// </summary>
		/// <param name="stream">Stream.</param>
		/// <returns></returns>
		ValidationResult Validate(Stream stream);
	}
}

