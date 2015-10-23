using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeDXMLLoader.Implementation.Model.ModelInterna
{
    class Triangle
    {
        public Vertex V1;
        public Vertex V2;
        public Vertex V3;

        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
        }

        
    }
}
