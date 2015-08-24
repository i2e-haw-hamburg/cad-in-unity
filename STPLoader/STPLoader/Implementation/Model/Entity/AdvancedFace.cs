using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    public class AdvancedFace : Entity
    {
        public string Info;
        public IList<long> FaceBoundIds;
        public long SurfaceId;
        public bool Boo;

        public override void Init()
        {
            Info = ParseHelper.Parse<string>(Data[0]);
            FaceBoundIds = ParseHelper.ParseList<string>(Data[1]).Select(ParseHelper.ParseId).ToList();
            SurfaceId = ParseHelper.ParseId(Data[2]);
            Boo = ParseHelper.Parse<bool>(Data[3]);
        }

        public override string ToString()
        {
            return String.Format("<AdvancedFace({0}, {1}, {2}, {3})", Info, FaceBoundIds, SurfaceId, Boo);
        }
    }

}
