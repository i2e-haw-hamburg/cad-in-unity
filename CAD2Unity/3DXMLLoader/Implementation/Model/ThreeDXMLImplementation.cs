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
            var product = Get<Reference3D>(1);
            var mainParts = Aggregated<Instance3D>(product.Id)
                .Select(x => x.InstanceOf)
                .Select(Get<Reference3D>);
            var mainPartShells = mainParts.Select(x => Aggregated<InstanceRep>(x.Id))
                .SelectMany(x => x)
                .Select(x => Get<ReferenceRep>(x.InstanceOf))
                .Select(Part.FromReferenceRep).ToList();
            var others = mainParts.Select(x => Aggregated<Instance3D>(x.Id))
                .SelectMany(x => x).ToList();
            var subPartShells = others
                .Select(x => Get<Reference3D>(x.InstanceOf))
                .Select(x => Aggregated<InstanceRep>(x.Id))
                .SelectMany(x => x)
                .Select(x => Get<ReferenceRep>(x.InstanceOf))
                .Select(Part.FromReferenceRep).ToList();
            var model = new BasicLoader.Implementation.Model.Model
            {
                Name = Header.Name,
                Author = Header.Author,
                Parts = mainPartShells.Concat(subPartShells).ToList()
            };

            return model;
        }

        private IList<T> InstanceOf<T>(int instanceOf)
        {
            var type = typeof(T);
            if (type == typeof(Instance3D))
            {
                var el = ThreeDInstances.Where(x => x.InstanceOf == instanceOf);
                return el.Select(x => (T)Convert.ChangeType(x, type)).ToList();
            }
            else if (type == typeof(InstanceRep))
            {
                var el = InstanceReps.Where(x => x.InstanceOf == instanceOf);
                return el.Select(x => (T)Convert.ChangeType(x, type)).ToList();
            }
            throw new Exception("Type for T not found.");
        }

        private IList<T> Aggregated<T>(int aggregatedBy)
        {
            var type = typeof(T);
            if (type == typeof(Instance3D))
            {
                var el = ThreeDInstances.Where(x => x.AggregatedBy == aggregatedBy);
                return el.Select(x => (T)Convert.ChangeType(x, type)).ToList();
            }
            else if (type == typeof(InstanceRep))
            {
                var el = InstanceReps.Where(x => x.AggregatedBy == aggregatedBy);
                return el.Select(x => (T)Convert.ChangeType(x, type)).ToList();
            }
            throw new Exception("Type for T not found.");
        }

    }
}
