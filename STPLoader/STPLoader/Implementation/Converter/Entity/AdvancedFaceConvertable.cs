using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using AForge.Math;
using STPLoader;
using STPLoader.Implementation.Model.Entity;

namespace STPConverter.Implementation.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class AdvancedFaceConvertable : IConvertable
    {
        private readonly AdvancedFace _face;
        private readonly IStpModel _model;

        public AdvancedFaceConvertable(AdvancedFace face, IStpModel model)
        {
            _face = face;
            _model = model;
            Init();
        }
        
        private void Init()
        {
            var bounds = _face.BoundIds.Select(_model.Get<Bound>);
            var surface = _model.Get<Surface>(_face.SurfaceId);
            var surfaceConvertable = new SurfaceConvertable(surface, _model);
            // create convertable for all faces and merge points and indices
            var convertables = bounds.Select(bound => new BoundConvertable(bound, _model)).Select(c => Tuple.New(c.Points, c.Indices)).ToList();
            convertables.Add(Tuple.New(surfaceConvertable.Points, surfaceConvertable.Indices));

            Points = convertables.Select(c => c.First).SelectMany(p => p).ToList();
            Indices = convertables.Aggregate(Tuple.New(0, new List<int>()), Tuple.AggregateIndices).Second;
        }

        public IList<Vector3> Points { get; private set; }
        public IList<int> Indices { get; private set; }
    }
}
