using System;
using System.Collections.Generic;
using System.Globalization;
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
            var instance = new Instance3D(id, name)
            {
                AggregatedBy = ParseUtility.ValueOfDescendant(xElement, "IsAggregatedBy", Convert.ToInt32, 0),
                InstanceOf = ParseUtility.ValueOfDescendant(xElement, "IsInstanceOf", Convert.ToInt32, 0),
                RelativeMatrix =
                    ParseUtility.ValueOfDescendant<IList<double>>(xElement, "RelativeMatrix",
                        ParseList, new List<double>())
            };
            return instance;
        }

        public static IList<double> ParseList(string s)
        {
            var elements = s.Split();
            var list = elements.Select(x => Convert.ToDouble(x, CultureInfo.InvariantCulture))
                .ToList();
            return list;
        }  
    }
}