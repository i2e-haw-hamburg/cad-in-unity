using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STPLoader.Implementation.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class FileSchema
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="schemaList"></param>
        public FileSchema(IList<string> schemaList)
        {
            Schemas = schemaList;
        }
        /// <summary>
        /// 
        /// </summary>
        IList<string> Schemas { get; set; }

        public override string ToString()
        {
            return String.Format("<FileSchema({0})>", Schemas);
        }
    }
}
