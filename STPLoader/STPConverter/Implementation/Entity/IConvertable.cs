using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Math;

namespace STPConverter.Implementation.Entity
{
    interface IConvertable
    {
        IList<Vector3> Points { get; }
        IList<int> Indices { get; }
    }
}
