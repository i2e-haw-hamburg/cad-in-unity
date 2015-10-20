using System;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;

namespace ThreeDXMLLoader.Implementation.Model
{
    public class Reference3D
    {
        private Reference3D(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public static Reference3D FromXDocument(XElement xElement)
        {
            var id = int.Parse(xElement.Attribute(XName.Get("id")).Value);
            var name = xElement.Attribute(XName.Get("name")).Value;
            return new Reference3D(id, name);
        }
    }
}