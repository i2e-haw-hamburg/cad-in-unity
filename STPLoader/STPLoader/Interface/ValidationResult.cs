using System;

namespace STPLoader
{
	/// <summary>
	/// Validation result.
	/// </summary>
	public class ValidationResult
	{
		private bool _valid;
		private string _message;

		public ValidationResult (bool valid) : this(valid, "")
		{
		}

		public ValidationResult (bool valid, string message)
		{
			_valid = valid;
			_message = message;
		}
	}

}

