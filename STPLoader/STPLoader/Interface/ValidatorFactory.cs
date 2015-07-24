using System;
using STPLoader.Implementation.Validator;
using STPLoader.Implementation.Parser;

namespace STPLoader
{
	public static class ValidatorFactory
	{
		public static IValidator CreateValidator() {
			return new STPValidator(new STPParser());
		}
	}
}

