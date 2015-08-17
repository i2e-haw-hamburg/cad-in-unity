using System;

namespace STPLoader.Implementation.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class StpHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public FileDescription Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FileName Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FileSchema Schema { get; set; }

        public override string ToString()
        {
            return String.Format("<StpHeader({0}, {1}, {2})>", Description, Name, Schema);
        }
    }
}