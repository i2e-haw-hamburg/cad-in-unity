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
        private string _name;
        private IList<IModel> _models;

        //TODO dont understand, dont compile
        //public IList<IModel> Models => new List<IModel> {this};

        //new Implementation from the the line above.
        public IList<IModel> Models {
            get { return _models; }
            private set { _models = value; }
        }

        public Model()
        {
            _models = new List<IModel>(){this};
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
    }
}