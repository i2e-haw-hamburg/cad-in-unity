using System;
using System.Collections.Generic;
using System.Linq;
using BasicLoader;

namespace ThreeDXMLLoader.Implementation.Model
{
    /// <summary>
    /// An implementation for a 3DXml model.
    /// </summary>
    class ThreeDXMLImplementation
    {
        /// <summary>
        /// the header of the 3DXml, with all mandatory and some optional fields
        /// </summary>
        public Header Header
        {
            get { return _header; }
            set { _header = value; }
        }

        public IList<Reference3D> ThreeDReferences { get; set; }
        public IList<Instance3D> ThreeDInstances { get; set; }
        public IList<InstanceRep> InstanceReps { get; set; }
        public IList<ReferenceRep> ReferenceReps { get; set; }

        private Header _header;
        /// <summary>
        /// creates a new 3DXmlImplementation instance, except the header all other fields
        /// are empty and will be initialized via setter injection.
        /// </summary>
        /// <param name="header"></param>
        public ThreeDXMLImplementation(Header header)
        {
            _header = header;
        }

        /// <summary>
        /// 
        /// </summary>
       public T Get<T>(int id)
        {
            var type = typeof (T);
            if (type == typeof (Reference3D))
            {
                return (T)Convert.ChangeType(ThreeDReferences.First(x => x.Id == id), type);
            }
            if (type == typeof (Instance3D))
            {
                return (T)Convert.ChangeType(ThreeDInstances.First(x => x.Id == id), type);
            }
            if (type == typeof(ReferenceRep))
            {
                return (T)Convert.ChangeType(ReferenceReps.First(x => x.Id == id), type);
            }
            if (type == typeof (InstanceRep))
            {
                return (T)Convert.ChangeType(InstanceReps.First(x => x.Id == id), type);
            }
            throw new Exception("Type for R not found.");
        }

        /// <summary>
        /// Parses the 3DXML discription and translate its to the internal IModel representation
        /// </summary>
        /// <returns>A model implementation</returns>
        public IModel ToModel()
        {
            var model = new BasicLoader.Implementation.Model.Model
            {
                Name = Header.Name,
                Author = Header.Author,
                Parts =
                    InstanceReps.Select(x => x.InstanceOf)
                        .Select(Get<ReferenceRep>)
                        .Select(Part.FromReferenceRep)
                        .ToList()
            };

            return model;
        }
        

    }
}
