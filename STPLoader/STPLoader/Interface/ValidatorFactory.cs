using System;
using STPLoader.Implementation.Parser;
using STPLoader.Implementation.Validator;

namespace STPLoader
{
	public static class ValidatorFactory
	{
		public static IValidator CreateValidator() {
            return new StpValidator(new StpParser());
		}
	}

}

