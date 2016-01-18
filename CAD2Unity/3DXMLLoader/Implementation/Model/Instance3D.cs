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

        public Instance3D(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Vector3 Position { get; set; }

        public Vector4 Rotation { get; set; }
    }
}