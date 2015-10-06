using System;
using CADLoader;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Validator
{
	/// <summary>
	/// STP validator.
	/// </summary>
	class StpValidator : IValidator
	{
		private IParser _parser;

		/// <summary>
		/// Initializes a new instance of the <see cref="StpValidator"/> class.
		/// </summary>
		public StpValidator (IParser parser)
		{
			_parser = parser;
		}

		#region IValidator implementation
		/// <summary>
		/// 
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
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

