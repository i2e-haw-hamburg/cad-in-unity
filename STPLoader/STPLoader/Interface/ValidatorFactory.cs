using System;
using STPLoader.Implementation.Parser;
using STPLoader.Implementation.Validator;

namespace STPLoader
{
    /// <summary>
    /// 
    /// </summary>
	public static class ValidatorFactory
	{
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public static IValidator CreateValidator() {
            return new StpValidator(new StpParser());
		}
	}

}

