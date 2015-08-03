using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace STPLoader.Implementation.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class StpData
    {
        private IDictionary<long, Entity> _entites;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entites"></param>
        public StpData(IDictionary<long, Entity> entites)
        {
            _entites = entites;
        }

        public override string ToString()
        {
            return String.Format("<StpData({0})>", String.Join(",", _entites.Select(pair => String.Format("{0} => {1}", pair.Key, pair.Value)).ToArray()));
        }
    }
}
