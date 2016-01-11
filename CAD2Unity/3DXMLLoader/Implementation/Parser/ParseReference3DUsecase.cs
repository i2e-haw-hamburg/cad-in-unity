using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ThreeDXMLLoader.Implementation.Model;

namespace ThreeDXMLLoader.Implementation.Parser
{
    class ParseReference3DUsecase
    {
        public static Reference3D FromXDocument(XElement xElement)
        {
            var id = int.Parse(xElement.Attribute(XName.Get("id")).Value);
            var name = xElement.Attribute(XName.Get("name")).Value;
            return new Reference3D(id, name);
        }
    }
}
