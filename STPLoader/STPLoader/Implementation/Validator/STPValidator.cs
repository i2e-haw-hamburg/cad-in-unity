using System;

namespace STPLoader
{
	/// <summary>
	/// STP validator.
	/// </summary>
	public class STPValidator : IValidator
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="STPLoader.STPValidator"/> class.
		/// </summary>
		public STPValidator ()
		{
		}

		#region IValidator implementation
		public ValidationResult Validate (IParser parser, System.IO.Stream stream)
		{
			try {
				parser.Parse(stream);
				return new ValidationResult(true);
			} catch(ParsingException ex) {
				return new ValidationResult(false, ex.Message);
			}
		}
		#endregion
	}
}

