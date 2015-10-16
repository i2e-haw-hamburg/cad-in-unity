using System.Collections.Generic;
using BasicLoader;

namespace ThreeDXMLLoader.Implementation.Model
{
    /// <summary>
    /// 
    /// </summary>
    class ThreeDXMLImplementation
    {
        private Header _header;
        private IDictionary<string, ThreeDRepFile> _representationFiles;

        public ThreeDXMLImplementation(Header header)
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
