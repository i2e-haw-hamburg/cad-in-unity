using STPLoader;
using STPLoader.Implementation.Parser;

namespace STPConverter
{
    public static class ConverterFactory
    {
        public static IConverter Create()
        {
            return new Converter();
        }
    }
}
