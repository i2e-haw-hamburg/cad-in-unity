using System;
using STPConverter;
using STPLoader;
using STPLoader.Interface;

namespace Example
{
	class MainClass
	{
        private static IConverter _converter = ConverterFactory.Create();
        private static IParser _parser = ParserFactory.Create();

		public static void Main (string[] args)
		{
			var loader = LoaderFactory.CreateFileLoader ("Gehaeuserumpf.stp");

            var model = _parser.Parse(loader.Load());
            var convertedModel = _converter.Convert(model);

            Console.WriteLine(convertedModel);
		    Console.ReadKey();
		}
	}
}
