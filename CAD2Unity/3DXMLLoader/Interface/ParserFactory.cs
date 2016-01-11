using BasicLoader;

namespace ThreeDXMLLoader
{
    public static class ParserFactory
    {
        public static IParser Create()
        {
            return new Implementation.Parser.ThreeDXMLParser();
        }
    }
}
