using System;
using System.Linq;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class FaceOuterBound : Bound
    {
        public override string ToString()
        {
            return String.Format("<FaceOuterBound({0}, {1}, {2})", Info, PointId, Boo);
        }
    }

}
