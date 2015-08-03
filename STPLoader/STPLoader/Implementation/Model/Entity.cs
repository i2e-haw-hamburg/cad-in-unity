using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STPLoader.Implementation.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Entity
    {
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
    }
}
