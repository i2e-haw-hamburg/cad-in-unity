using System;
using System.Collections.Generic;
using System.Linq;
using AForge.Math;
using STPLoader;
using STPLoader.Implementation.Model.Entity;

namespace STPConverter.Implementation.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class ClosedShellConveratable : IConvertable
    {
        private readonly ClosedShell _closedShell;
        private readonly IStpModel _model;

        public ClosedShellConveratable(ClosedShell closedShell, IStpModel model)
        {
            _closedShell = closedShell;
            _model = model;
            Init();
        }

        private void Init()
        {
            var faces = _closedShell.PointIds.Select(_model.Get<AdvancedFace>);
            // create convertable for all faces and merge points and indices
            var convertables = faces.Select(face => new AdvancedFaceConvertable(face, _model)).Select(c => Tuple.New(c.Points, c.Indices));

            Points = convertables.Select(c => c.First).SelectMany(p => p).ToList();
            Indices = convertables.Aggregate(Tuple.New(0, new List<int>()), Tuple.AggregateIndices).Second;
        }

        public IList<Vector3> Points { get; private set; }
        public IList<int> Indices { get; private set; }
    }
}
