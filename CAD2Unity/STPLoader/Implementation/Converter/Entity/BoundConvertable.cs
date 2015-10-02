using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Math;
using STPLoader;
using STPLoader.Implementation.Model.Entity;

namespace STPConverter.Implementation.Entity
{
    class BoundConvertable : IConvertable
    {
        public IList<Vector3> Points { get; private set; }
        public IList<int> Indices { get; private set; }

        private readonly Bound _bound;
        private readonly IStpModel _model;

        public BoundConvertable(Bound bound, IStpModel model)
        {
            _bound = bound;
            _model = model;
            Init();
        }
        
        private void Init()
        {
            //var loop = _model.Get<EdgeLoop>(_bound.EdgeLoopId);

            Points = new List<Vector3>();
            Indices = new List<int>();   
        }
    }
}
