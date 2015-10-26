using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Math;

namespace ThreeDXMLLoader.Implementation.Model.ModelInterna
{
    class Triangle
    {
        public Vector3 V1;
        public Vector3 V2;
        public Vector3 V3;

        public Triangle(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
        }

        
    }
}
