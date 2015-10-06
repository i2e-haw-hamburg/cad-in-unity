using System.Collections.Generic;
using System.Linq;
using AForge.Math;
using BasicLoader.Implementation.Model.Constraint;
using BasicLoader.Interface;
using CADLoader;
using CADLoader.Implementation.Parser;

namespace BasicLoader.Implementation.Model
{
    public class Model : IModel
    {
        private IList<Facet> _facets;

        public IList<IModel> Models => new List<IModel> {this};

        public IConstraint GetConstraint(IModel a, IModel b)
        {
            return new EmptyConstraint();
        }

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

        public IList<Vector3> Vertices
        {
            get { return Facets.SelectMany(x => x.Verticies.ToArray()).ToList(); }
        }

        public IList<int> Triangles => Enumerable.Range(0, Facets.Count() * 3).ToList();

        public override string ToString()
        {
            return $"Model with {_facets.Count} facets";
        }
        
    }
}