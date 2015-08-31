using System;
using System.Collections.Generic;
using System.Linq;
using AForge.Math;
using STPLoader;
using STPLoader.Implementation.Model.Entity;

namespace STPConverter.Implementation.Entity
{
    public class CylindricalSurfaceConvertable : IConvertable
    {
        private readonly CylindricalSurface _surface;
        private readonly IStpModel _model;
        private const int Sides = 64;

        public CylindricalSurfaceConvertable(Surface surface, IStpModel model)
        {
            _surface = (CylindricalSurface)surface;
            _model = model;
            Init();
        }

        private void Init()
        {
            var placement = _model.Get<Axis2Placement3D>(_surface.PointId);
            var cartesianPoint = _model.Get<CartesianPoint>(placement.PointIds[0]);
            var direction = _model.Get<DirectionPoint>(placement.PointIds[1]);
            var directionX = _model.Get<DirectionPoint>(placement.PointIds[2]);

            Points = new List<Vector3> { cartesianPoint.Vector };
            var x = new Vector3(1, 0, 0);
            var y = new Vector3(0, 1, 0);
            var ax = Math.Acos(Vector3.Dot(direction.Vector, x) / (direction.Vector.Norm * x.Norm));
            var ay = Math.Acos(Vector3.Dot(direction.Vector, y) / (direction.Vector.Norm * y.Norm));

            var rotationMatrix = Matrix3x3.CreateFromYawPitchRoll((float)(Math.PI / 2 - ax), (float)(Math.PI / 2 - ay), 0);

            for (int i = 0; i < Sides; i++)
            {
                var angle = 360 - (i * 360d / Sides);
                angle = angle * 2 * Math.PI / 360d;
                // calculate point on unit circle and multiply by radius
                var vector = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0) * (float)_surface.Radius;
                // change normal vector to direction vector
                vector = rotationMatrix * vector;
                // add midpoint position vector
                vector = vector + cartesianPoint.Vector;
                Points.Add(vector);
            }

            Indices = Enumerable.Range(1, Sides).Select(i => new int[] { 0, i, (i % Sides) + 1 }).SelectMany(d => d).ToList();
        }

        public IList<Vector3> Points { get; private set; }
        public IList<int> Indices { get; private set; }
    }
}