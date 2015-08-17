using System;
using System.Linq;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class ToroidalSurface : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Info;
        /// <summary>
        /// 
        /// </summary>
        public long PointId;

        public double Radius;
        public double Radius2;

        public override void Init()
        {
            Info = ParseHelper.Parse<string>(Data[0]);
            PointId = ParseHelper.ParseId(Data[1]);
            Radius = ParseHelper.Parse<double>(Data[2]);
            Radius2 = ParseHelper.Parse<double>(Data[3]);
        }

        public override string ToString()
        {
            return String.Format("<ToroidalSurface({0}, {1}, {2}, {3})", Info, PointId, Radius, Radius2);
        }
    }

}
