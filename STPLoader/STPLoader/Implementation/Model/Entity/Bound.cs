using System;
using System.Linq;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class Bound : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Info;
        /// <summary>
        /// 
        /// </summary>
        public long EdgeLoopId;

        public bool Boo;

        public override void Init()
        {
            Info = ParseHelper.Parse<String>(Data[0]);
            EdgeLoopId = ParseHelper.ParseId(Data[1]);
            Boo = ParseHelper.Parse<bool>(Data[2]);
        }

    }

}
