using BasicLoader;
using CADLoader;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = ThreeDXMLLoader.ParserFactory.Create();
            parser.Parse(LoaderFactory.CreateFileLoader(@"C:\Users\squad\Downloads\CAD_Daten_Lagertraeger\ZUSAMMENBAU_Deckel_Gehaeuse_text.3dxml").Load());
        }
    }
}
