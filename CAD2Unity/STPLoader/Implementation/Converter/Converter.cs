using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Math;
using STPConverter.Implementation.Entity;
using STPLoader;
using STPLoader.Implementation.Model.Entity;

namespace STPConverter
{
    class Converter : IConverter
    {

        public MeshModel Convert(IStpModel model)
        {
            var vectors = new List<Vector3>();
            var indices = new List<int>();

            GetValue<ClosedShell>(model, indices, vectors);
            var mesh = new MeshModel(vectors, indices);

            return mesh;
        }

        private void GetValue<T>(IStpModel model, List<int> indices, List<Vector3> vectors) where T : Entity
        {
            foreach (var element in model.All<T>())
            {
                var offset = vectors.Count;
                var convertable = CreateConvertable(element, model);
                var circleVectors = convertable.Points;
                var circleIndices = convertable.Indices;
                vectors.AddRange(circleVectors);
                indices.AddRange(circleIndices.Select(x => x + offset));
            }
        }

        private static IConvertable CreateConvertable<T>(T element, IStpModel model) where T : Entity
        {
            var type = typeof (T);
            if (type == typeof(Circle))
            {
                return new CircleConvertable(element as Circle, model);
            }
            if (type == typeof(Line))
            {
                return new LineConvertable(element as Line, model);
            }
            if (type == typeof(AdvancedFace))
            {
                return new AdvancedFaceConvertable(element as AdvancedFace, model);
            }
            if (type == typeof(ClosedShell))
            {
                return new ClosedShellConveratable(element as ClosedShell, model);
            }
            throw new Exception("Not supported");
        }

    }
}
