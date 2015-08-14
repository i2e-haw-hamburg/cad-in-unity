using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    class VertexPoint : Entity
    {
        public string Info;
        public long PointId;

        public override void Init()
        {
            Info = ParseHelper.ParseString(Data[0]);
            PointId = ParseHelper.ParseId(Data[1]);
        }

        public override string ToString()
        {
            return String.Format("<VertexPoint({0}, {1})", Info, PointId);
        }
    }

}
