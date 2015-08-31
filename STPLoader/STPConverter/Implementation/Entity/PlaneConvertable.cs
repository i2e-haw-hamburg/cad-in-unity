using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Math;
using STPLoader;
using STPLoader.Implementation.Model.Entity;

namespace STPConverter.Implementation.Entity
{
    class PlaneConvertable : IConvertable
    {
        private readonly Plane _surface;
        private readonly IStpModel _model;

        public PlaneConvertable(Surface surface, IStpModel model)
        {
            _surface = (Plane)surface;
            _model = model;
            Init();
        }

        private void Init()
        {
            var planeAxis = _model.Get<Axis2Placement3D>(_surface.AxisId);
            
            Points = new List<Vector3>();
            Indices = new List<int>();
        }

        public IList<Vector3> Points { get; private set; }
        public IList<int> Indices { get; private set; }
    }
}
