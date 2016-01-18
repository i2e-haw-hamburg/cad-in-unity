using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using AForge.Math;
using ThreeDXMLLoader.Implementation.Model;

namespace ThreeDXMLLoader.Implementation.Parser
{
    public static class ParseInstance3DUsecase
    {
        public static Instance3D FromXDocument(XElement xElement)
        {
            var id = int.Parse(xElement.Attribute(XName.Get("id")).Value);
            var name = xElement.Attribute(XName.Get("name")).Value;
            var matrix = ParseUtility.ValueOfDescendant<IList<double>>(xElement, "RelativeMatrix", ParseList, new List<double>());
            var instance = new Instance3D(id, name)
            {
                AggregatedBy = ParseUtility.ValueOfDescendant(xElement, "IsAggregatedBy", Convert.ToInt32, 0),
                InstanceOf = ParseUtility.ValueOfDescendant(xElement, "IsInstanceOf", Convert.ToInt32, 0),
                Rotation = new Vector4(),
                Position = new Vector3((float)matrix[9], (float)matrix[10], (float)matrix[11])
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