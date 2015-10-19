using System.Xml.Linq;

namespace ThreeDXMLLoader.Implementation.Model
{

    interface IThreeDArchiv
    {
        XDocument GetManifest();

        XDocument GetNextDocument(string name);
    }
}