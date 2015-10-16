using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicLoader;

namespace ThreeDXMLLoader.Implementation.Model
{
    /// <summary>
    /// 
    /// </summary>
    class ThreeDXML
    {
        private Header _header;
        private IDictionary<string, ThreeDRepFile> _representationFiles;

        public ThreeDXML(Header header)
        {
            Header = header;
        }

        /// <summary>
        /// 
        /// </summary>
        public Header Header
        {
            get
            {
                return _header;
            }

            set
            {
                _header = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IModel ToModel()
        {
            var model = new BasicLoader.Implementation.Model.Model {Name = Header.Name};
            
            return model;
        }
    }
}
