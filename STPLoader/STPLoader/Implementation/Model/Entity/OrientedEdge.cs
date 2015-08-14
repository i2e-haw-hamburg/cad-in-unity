using System;
using System.Linq;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    class OrientedEdge : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Info;
        /// <summary>
        /// 
        /// </summary>
        public long[] PointIds;

        public bool Boo;

        public override void Init()
        {
            Info = ParseHelper.ParseString(Data[0]);
            PointIds = Data.Skip(1).Take(3).Select(ParseHelper.ParseId).ToArray();
            Boo = ParseHelper.ParseBool(Data[4]);
        }

        public override string ToString()
        {
            return String.Format("<OrientedEdge({0}, {1}, {2})", Info, PointIds, Boo);
        }
    }

}
