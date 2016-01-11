using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeDXMLLoader.Implementation.Model.ModelInterna
{
    class Shell
    {
        /// <summary>
        /// if this mesh is lod able accuracy discribes the LOD degree
        /// Note a smaller value means a higher accuracy
        /// if the shell has no lod representation accuracy = 0
        /// </summary>
        public double Accuracy;
        public IList<Triangle> Triangles;
        public Boolean HasLod { get; private set;}
    

        public Shell(double accuracy, IList<Triangle> triangles)
        {
            Accuracy = accuracy;
            Triangles = triangles;
            HasLod = true;
        }

        public Shell(IList<Triangle> triangles)
        {
            Triangles = triangles;
            Accuracy = 100.0;
            HasLod = false;
        }

    }
}
