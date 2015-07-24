using System;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Validator
{
	/// <summary>
	/// STP validator.
	/// </summary>
	class STPValidator : IValidator
	{
		private IParser _parser;

		/// <summary>
		/// Initializes a new instance of the <see cref="STPLoader.STPValidator"/> class.
		/// </summary>
		public STPValidator (IParser parser)
		{
			_parser = parser;
		}

		#region IValidator implementation
		public ValidationResult Validate (System.IO.Stream stream)
		{
			try {
				_parser.Parse(stream);
				return new ValidationResult(true);
			} catch(ParsingException ex) {
				return new ValidationResult(false, ex.Message);
			}
		}
		#endregion
	}
}

