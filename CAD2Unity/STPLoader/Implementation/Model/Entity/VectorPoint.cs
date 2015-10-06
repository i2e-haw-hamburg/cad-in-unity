using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    public class VectorPoint : Entity
    {
        public string Info;
        public long PointId;
        public double Length;

        public override void Init()
        {
            Info = ParseHelper.ParseString(Data[0]);
            PointId = ParseHelper.ParseId(Data[1]);
            Length = ParseHelper.Parse<double>(Data[2]);
        }

        public override string ToString()
        {
            return String.Format("<VectorPoint({0}, {1})", Info, PointId);
        }
    }

}
