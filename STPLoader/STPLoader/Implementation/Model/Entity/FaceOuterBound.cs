using System;
using System.Linq;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class FaceOuterBound : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Info;
        /// <summary>
        /// 
        /// </summary>
        public long PointId;

        public bool Boo;

        public override void Init()
        {
            Info = ParseHelper.Parse<string>(Data[0]);
            PointId = ParseHelper.ParseId(Data[1]);
            Boo = ParseHelper.Parse<bool>(Data[2]);
        }

        public override string ToString()
        {
            return String.Format("<FaceOuterBound({0}, {1}, {2})", Info, PointId, Boo);
        }
    }

}
