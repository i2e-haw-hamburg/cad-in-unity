using System.Collections.Generic;

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
    }
}