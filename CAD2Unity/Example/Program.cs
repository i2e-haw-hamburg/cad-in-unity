using BasicLoader;
using CADLoader;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = ThreeDXMLLoader.ParserFactory.Create();
            parser.Parse(LoaderFactory.CreateFileLoader(@"C:\HAW\cad-in-unity\3D XML Example\CATRepImage.3dxml").Load());
        }
    }
}
