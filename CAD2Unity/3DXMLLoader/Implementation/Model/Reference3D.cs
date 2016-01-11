using System;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;

namespace ThreeDXMLLoader.Implementation.Model
{
    public class Reference3D
    {
        public Reference3D(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

    }
}