using System;
using System.Linq;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    class Axis2Placement3D : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Info;
        /// <summary>
        /// 
        /// </summary>
        public long[] PointIds;

        public override void Init()
        {
            Info = ParseHelper.ParseString(Data[0]);
            PointIds = Data.Skip(1).Select(ParseHelper.ParseId).ToArray();
        }

        public override string ToString()
        {
            return String.Format("<Axis2Placement3D({0}, {1})", Info, PointIds);
        }
    }

}
