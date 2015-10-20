using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using ThreeDXMLLoader.Implementation.Model;

namespace ThreeDXMLLoader.Implementation.Parser
{
    public class ParseInstance3DUsecase
    {
        public static Instance3D FromXDocument(XElement xElement)
        {
            var id = int.Parse(xElement.Attribute(XName.Get("id")).Value);
            var name = xElement.Attribute(XName.Get("name")).Value;
            var instance = new Instance3D(id, name);
            instance.AggregatedBy = ParseUtility.ValueOfDescendant(xElement, "IsAggregatedBy", Convert.ToInt32, 0);
            instance.InstanceOf = ParseUtility.ValueOfDescendant(xElement, "IsInstanceOf", Convert.ToInt32, 0);
            instance.RelativeMatrix = ParseUtility.ValueOfDescendant<IList<double>>(xElement, "RelativeMatrix", s => s.Split().Select(Convert.ToDouble).ToList(), new List<double>());
            return instance;
        }
    }
}