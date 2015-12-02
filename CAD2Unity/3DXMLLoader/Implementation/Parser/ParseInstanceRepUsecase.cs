using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using ThreeDXMLLoader.Implementation.Model;

namespace ThreeDXMLLoader.Implementation.Parser
{
    class ParseInstanceRepUsecase
    {
        public static InstanceRep FromXDocument(XElement xElement)
        {
            var id = int.Parse(xElement.Attribute(XName.Get("id")).Value);
            var name = xElement.Attribute(XName.Get("name")).Value;
            var instance = new InstanceRep(id, name)
            {
                AggregatedBy = ParseUtility.ValueOfDescendant(xElement, "IsAggregatedBy", Convert.ToInt32, 0),
                InstanceOf = ParseUtility.ValueOfDescendant(xElement, "IsInstanceOf", Convert.ToInt32, 0)
            };
            return instance;
        }
    }
}