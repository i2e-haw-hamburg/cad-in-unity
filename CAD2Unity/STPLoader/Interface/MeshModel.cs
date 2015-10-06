using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AForge.Math;

namespace STPConverter
{
    public class MeshModel
    {
        public string Meta;
        private readonly IList<Vector3> _points;
        private readonly IList<int> _triangles;

        public MeshModel(IList<Vector3> points, IList<int> triangles)
        {
            _points = points;
            _triangles = triangles;
        }

        public IList<Vector3> Points
        {
            get { return _points; }
        }

        public IList<int> Triangles
        {
            get { return _triangles; }
        }

        public override string ToString()
        {
            return String.Format("<MeshModel({0}, {1})>",
                String.Join("|", Points.Select(x => x.ToString()).ToArray()),
                String.Join("|", Triangles.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray()));
        }
    }
}
