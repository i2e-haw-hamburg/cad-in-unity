using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class EdgeCurve : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Info;
        /// <summary>
        /// 
        /// </summary>
        public IList<long> PointIds;
        public bool Boo;
        
        public override void Init()
        {
            Info = ParseHelper.Parse<string>(Data[0]);
            PointIds = new List<long> { ParseHelper.ParseId(Data[1]), ParseHelper.ParseId(Data[2]), ParseHelper.ParseId(Data[3]) };
            Boo = ParseHelper.Parse<bool>(Data[4]);
        }

        public override string ToString()
        {
            return String.Format("<EdgeCurve({0}, {1}, {2})", Info, PointIds, Boo);
        }
    }

}
