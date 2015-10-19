using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreeDXMLLoader.Implementation.Model.ModelInterna;

namespace ThreeDXMLLoader.Implementation.Model
{
    class ReferenceRep
    {
        public string ReferenceType { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public string Usage { get; set; }

        public IList<Face> Faces { get; set; }
    }
}
