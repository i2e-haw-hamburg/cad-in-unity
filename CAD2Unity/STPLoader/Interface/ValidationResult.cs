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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valid"></param>
        /// <param name="message"></param>
	    public ValidationResult (bool valid, string message = "")
		{
			_valid = valid;
			_message = message;
		}

	    public override string ToString()
	    {
	        return String.Format("<ValidationResult({0}, {1})>", _valid, _message);
	    }
	}

}

