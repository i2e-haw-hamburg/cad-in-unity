using System;

namespace STLLoader.Implementation.Parser
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

