using System.Collections.Generic;
using System.Linq;
using AForge.Math;
using BasicLoader.Implementation.Model.Constraint;
using BasicLoader.Interface;
using CADLoader.Implementation.Parser;

namespace BasicLoader.Implementation.Model
{
    public class Model : IModel
    {
        private IList<Facet> _facets;
        private string _name;
        private IList<IPart> _parts;
        
        public IList<IPart> Parts {
            get { return _parts; }
            set { _parts = value; }
        }

        public Model()
        {
            _parts = new List<IPart>();
        }


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

        public IList<int> Triangles
        {
            get { return Enumerable.Range(0, Facets.Count()*3).ToList(); }
        }

        public override string ToString()
        {
            return @"Model with {_facets.Count} facets";
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Author { get; set; }
    }
}