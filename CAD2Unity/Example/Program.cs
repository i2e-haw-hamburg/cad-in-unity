using BasicLoader;
using CADLoader;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = ThreeDXMLLoader.ParserFactory.Create();
            parser.Parse(LoaderFactory.CreateFileLoader("quad.3dxml").Load());
        }
    }
}
