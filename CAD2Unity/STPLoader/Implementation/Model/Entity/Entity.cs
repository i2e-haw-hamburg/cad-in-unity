using System;
using System.Collections.Generic;
using System.Linq;

namespace STPLoader.Implementation.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class Entity
    {
        public Entity()
        {}
       
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<string> Data { get; set; }

        public override string ToString()
        {
            return String.Format("<Entity({0}, {1}, {2})>", Id, Type, String.Join(", ", Data.ToArray()));
        }

        public virtual void Init()
        {
            
        }
    }
}
