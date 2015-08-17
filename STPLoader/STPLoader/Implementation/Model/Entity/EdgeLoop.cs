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
    public class EdgeLoop : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Info;
        /// <summary>
        /// 
        /// </summary>
        public IList<long> PointIds;
        
        public override void Init()
        {
            Info = ParseHelper.Parse<string>(Data[0]);
            PointIds = ParseHelper.ParseList<string>(Data[1]).Select(ParseHelper.ParseId).ToList();
        }

        public override string ToString()
        {
            return String.Format("<EdgeLoop({0}, {1})", Info, PointIds);
        }
    }

}
