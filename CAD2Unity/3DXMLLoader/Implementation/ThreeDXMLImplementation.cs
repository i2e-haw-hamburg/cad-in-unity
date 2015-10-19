using System.Collections.Generic;
using BasicLoader;
using ThreeDXMLLoader.Implementation.Model;

namespace ThreeDXMLLoader.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    class ThreeDXMLImplementation
    {
        private Header _header;
        private IDictionary<string, ThreeDRepFile> _representationFiles;
        private IDictionary<int, CatMaterialReference> _materials;

        /// <summary>
        /// maps the id of an material to an CatMaterialReference instance
        /// </summary>
        public IDictionary<int, CatMaterialReference> Materials
        {
            get { return _materials; }
            set { _materials = value; }
        }

        public ThreeDXMLImplementation(Header header)
        {
            _header = header;
            _materials = new Dictionary<int, CatMaterialReference>();
        }

        /// <summary>
        /// 
        /// </summary>
        public Header Header
        {
            get{return _header;}
            set{_header = value;}
        }

        /// <summary>
        /// Parses the 3DXML discription and translate its to the internal IModel representation
        /// </summary>
        /// <returns></returns>
        public IModel ToModel()
        {
            var model = new BasicLoader.Implementation.Model.Model {Name = Header.Name};
            
            return model;
        }

        private void ParseHeader()
        {
            
        }
    }
}
