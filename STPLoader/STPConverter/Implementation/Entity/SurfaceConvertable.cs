using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Math;
using STPLoader;
using STPLoader.Implementation.Model.Entity;

namespace STPConverter.Implementation.Entity
{
    class SurfaceConvertable : IConvertable
    {
        private readonly Surface _surface;
        private readonly IStpModel _model;

        public SurfaceConvertable(Surface surface, IStpModel model)
        {
            _surface = surface;
            _model = model;
            Init();
        }

        private void Init()
        {
            Points = new List<Vector3>();
            Indices = new List<int>();
        }

        public IList<Vector3> Points { get; private set; }
        public IList<int> Indices { get; private set; }
    }
}
