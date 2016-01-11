using System.Collections.Generic;
using AForge.Math;

namespace ThreeDXMLLoader.Implementation.Model
{
    public class Instance3D
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int AggregatedBy { get; set; }
        public int InstanceOf { get; set; }
        public IList<double> RelativeMatrix { get; set; }

        public Instance3D(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Vector3 Position => new Vector3((float)RelativeMatrix[9], (float)RelativeMatrix[10], (float)RelativeMatrix[11]);

        public Matrix3x3 Rotation => Matrix3x3.CreateFromColumns(
            new Vector3((float)RelativeMatrix[0], (float)RelativeMatrix[1], (float)RelativeMatrix[2]),
            new Vector3((float)RelativeMatrix[3], (float)RelativeMatrix[4], (float)RelativeMatrix[5]),
            new Vector3((float)RelativeMatrix[6], (float)RelativeMatrix[7], (float)RelativeMatrix[8]));
    }
}