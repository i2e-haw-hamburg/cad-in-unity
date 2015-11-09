using System;
using System.Collections.Generic;
using System.Linq;
using BasicLoader;

namespace ThreeDXMLLoader.Implementation.Model
{
    /// <summary>
    /// An implementation for a 3DXML model.
    /// </summary>
    class ThreeDXMLImplementation
    {
        private Header _header;

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
        public IList<ReferenceRep> ReferenceReps { get; set; }

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
        /// <returns></returns>
        public IModel ToModel()
        {
            var model = new BasicLoader.Implementation.Model.Model
            {
                Name = Header.Name,
                Author = Header.Author,
                Parts =
                    ThreeDInstances.Select(x => x.InstanceOf)
                        .Select(Aggregated<InstanceRep>)
                        .Where(x => x != null)
                        .Select(x => x.InstanceOf)
                        .Select(Get<ReferenceRep>)
                        .Select(Part.FromReferenceRep)
                        .ToList()
            };

            return model;
        }

        private T Aggregated<T>(int aggregatedBy)
        {
            var type = typeof(T);
            if (type == typeof(Instance3D))
            {
                var el = ThreeDInstances.FirstOrDefault(x => x.AggregatedBy == aggregatedBy);
                return el == null ? default(T) : (T)Convert.ChangeType(el, type);
            }
            else if (type == typeof(InstanceRep))
            {
                var el = InstanceReps.FirstOrDefault(x => x.AggregatedBy == aggregatedBy);
                return el == null ? default(T) : (T) Convert.ChangeType(el, type);
            }
            throw new Exception("Type for R not found.");
        }

    }
}
