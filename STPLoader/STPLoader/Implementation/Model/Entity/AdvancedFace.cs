using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    class AdvancedFace : Entity
    {
        public string Info;
        public IList<long> PointIds;
        public long PointId;
        public bool Boo;

        public override void Init()
        {
            Info = ParseHelper.Parse<string>(Data[0]);
            PointIds = ParseHelper.ParseList<string>(Data[1]).Select(ParseHelper.ParseId).ToList();
            PointId = ParseHelper.ParseId(Data[2]);
            Boo = ParseHelper.Parse<bool>(Data[3]);
        }

        public override string ToString()
        {
            return String.Format("<AdvancedFace({0}, {1}, {2}, {3})", Info, PointIds, PointId, Boo);
        }
    }

}
