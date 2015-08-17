using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Math;
using STPLoader;
using STPLoader.Implementation.Model.Entity;

namespace STPConverter.Implementation.Entity
{
    class CircleConvertable : IConvertable
    {
        private readonly Circle _circle;
        private readonly IStpModel _model;
        private const int Sides = 4;

        public CircleConvertable(Circle circle, IStpModel model)
        {
            _circle = circle;
            _model = model;
            Init();
        }

        private void Init()
        {
            var placement = _model.Get<Axis2Placement3D>(_circle.PointId);
            var cartesianPoint = _model.Get<CartesianPoint>(placement.PointIds[0]);
            var direction = _model.Get<DirectionPoint>(placement.PointIds[1]);

            Points = new List<Vector3> { cartesianPoint.Vector };

            for (int i = 0; i < Sides; i++)
            {
                var angle = -(i * 360d / Sides) * (180d / Math.PI);
                var vector = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0) * (float)_circle.Radius;
                vector = vector + cartesianPoint.Vector;
                Points.Add(vector);
            }

            Indices = Enumerable.Range(1, Sides).Select(i => new int[]{0, i, (i % Sides)+1}).SelectMany(x => x).ToList();
        }

        public IList<Vector3> Points { get; private set; }
        public IList<int> Indices { get; private set; }
    }
}
