using System;
using STPLoader;

namespace Example
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var loader = LoaderFactory.CreateFileLoader ("Gehaeuserumpf.stp");
			var data = loader.Load ();
			var validator = ValidatorFactory.CreateValidator ();

			var result = validator.Validate (data);

			Console.WriteLine (result);
		    Console.ReadKey();
		}
	}
}
