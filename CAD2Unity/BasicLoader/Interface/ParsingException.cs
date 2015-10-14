using System;

namespace BasicLoader
{
    /// <summary>
    /// 
    /// </summary>
	class ParsingException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
	    public ParsingException(string message) : base(message)
        {

        }
    }

}

