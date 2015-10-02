using System;
using System.Collections.Generic;
using System.Linq;
using AForge.Math;
using STLLoader.Implementation.Parser;

namespace STLLoader.Implementation.Model
{
    public class Model : IModel
    {
        private IList<Facet> _facets;

        public IList<Facet> Facets
        {
            get
            {
                return _facets;
            }

            set
            {
                _facets = value;
            }
        }

        public IList<Vector3> Vertices()
        {
            return _facets.SelectMany(x => x.Verticies.ToArray()).ToList();
        }

        public IList<int> Triangles()
        {
            return Enumerable.Range(0, _facets.Count()*3).ToList();
        }

        public override string ToString()
        {
            return $"STL Model with {_facets.Count} facets";
        }
        
    }
}