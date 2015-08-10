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
        private IDictionary<long, Entity.Entity> _entities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        public StpData(IDictionary<long, Entity.Entity> entities)
        {
            _entities = entities;
        }

        public IList<T> All<T>() where T : Entity.Entity
        {
            throw new NotImplementedException();
            var type = typeof (T);
            //return _entities.Values.Where<T>(e => e.GetType() == type).ToList();
        } 

        public override string ToString()
        {
            return String.Format("<StpData({0})>", String.Join(",\n", _entities.Select(pair => String.Format("{0} => {1}", pair.Key, pair.Value)).ToArray()));
        }
    }
}
