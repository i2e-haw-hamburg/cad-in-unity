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
        private IDictionary<string, ThreeDXMLFile> _representationFiles;
        private IDictionary<string, ReferenceRep> _internalReferenceRepresentation;
        private IDictionary<string, InstanceRep> _internalInstanceRepresentation;

        public ThreeDXMLImplementation(Header header)
        {
            _header = header;
        }

        /// <summary>
        /// 
        /// </summary>
        public Header Header
        {
            get{return _header;}
            set{_header = value;}
        }

        public IList<Reference3D> ThreeDReferences { get; set; }
        public IList<Instance3D> ThreeDInstances { get; set; }
        public IList<InstanceRep> InstanceReps { get; set; }

        /// <summary>
        /// Parses the 3DXML discription and translate its to the internal IModel representation
        /// </summary>
        /// <returns></returns>
        public IModel ToModel()
        {
            var model = new BasicLoader.Implementation.Model.Model {Name = Header.Name};
            
            return model;
        }

        /// <summary>
        /// Sorts the ThreeDRepFiles into the Models internal representation
        /// </summary>
        /// <param name="faces"></param>
        public void Fill3DRepresentation(IList<ReferenceRep> faces)
        {
             //TODO implement
        }

    }
}
