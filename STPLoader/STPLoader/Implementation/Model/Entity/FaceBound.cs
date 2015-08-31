using System;
using System.Linq;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class FaceBound : Bound
    {
        public override string ToString()
        {
            return String.Format("<FaceBound({0}, {1}, {2})", Info, PointId, Boo);
        }
    }

}
