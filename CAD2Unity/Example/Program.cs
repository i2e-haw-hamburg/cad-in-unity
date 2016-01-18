using System;
using BasicLoader;
using CADLoader;
using STLLoader;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = ParserFactory.Create();
            var result = parser.Parse(LoaderFactory.CreateFileLoader("C:\\Users\\squad\\Downloads\\Gehaeuserumpf.stl").Load());
            Console.Write(result);
            Console.ReadKey();
        }
    }
}
