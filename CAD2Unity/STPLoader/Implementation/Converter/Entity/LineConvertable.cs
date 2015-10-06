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
    public class LineConvertable : IConvertable
    {
        private readonly Line _line;
        private readonly IStpModel _model;
        private const double Thickness = 1;
        private const double Sides = 4;

        public LineConvertable(Line line, IStpModel model)
        {
            _line = line;
            _model = model;
            Init();
        }

        private void Init()
        {
            var s = _model.Get<CartesianPoint>(_line.Point1Id);
            var e = _model.Get<VectorPoint>(_line.Point2Id);
            var direction = _model.Get<DirectionPoint>(e.PointId);
            var endVector = s.Vector + direction.Vector * (float)e.Length;
            var x = new Vector3(1, 0, 0);
            var y = new Vector3(0, 1, 0);
            var ax = Math.Acos(Vector3.Dot(direction.Vector, x) / (direction.Vector.Norm * x.Norm));
            var ay = Math.Acos(Vector3.Dot(direction.Vector, y) / (direction.Vector.Norm * y.Norm));

            Points = new List<Vector3> { s.Vector };
            var rotationMatrix = Matrix3x3.CreateFromYawPitchRoll((float)(Math.PI / 2 - ax), (float)(Math.PI / 2 - ay), 0);

            for (var i = 0; i < Sides; i++)
            {
                var angle = 360 - (i * 360d / Sides);
                angle = angle * 2 * Math.PI / 360d;
                // calculate point on unit circle and multiply by radius
                var vector = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0) * (float)Thickness/2;
                // change normal vector to direction vector
                vector = rotationMatrix * vector;
                // add midpoint position vector
                vector = vector + s.Vector;
                Points.Add(vector);
            }
            Points.Add(endVector);

            for (var i = 0; i < Sides; i++)
            {
                var angle = 360 - (i * 360d / Sides);
                angle = angle * 2 * Math.PI / 360d;
                // calculate point on unit circle and multiply by radius
                var vector = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0) * (float)Thickness / 2;
                // change normal vector to direction vector
                vector = rotationMatrix * vector;
                // add midpoint position vector
                vector = vector + endVector;
                Points.Add(vector);
            }

            Indices = new List<int> { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 1, 5, 6, 7, 5, 7, 8, 5, 8, 9, 5, 9, 6, 1, 6, 7, 7, 2, 1, 2, 7, 8, 8, 3, 2, 3, 8, 9, 9, 4, 3, 4, 9, 6, 6, 1, 4};
        }

        public IList<Vector3> Points { get; private set; }
        public IList<int> Indices { get; private set; }
    }
}
