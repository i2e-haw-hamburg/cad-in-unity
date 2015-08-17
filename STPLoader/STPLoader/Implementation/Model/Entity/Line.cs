using System;
using System.Linq;
using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class Line : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Info;
        /// <summary>
        /// 
        /// </summary>
        public long Point1Id;

        public long Point2Id;

        public override void Init()
        {
            Info = ParseHelper.Parse<string>(Data[0]);
            Point1Id = ParseHelper.ParseId(Data[1]);
            Point2Id = ParseHelper.ParseId(Data[2]);
        }

        public override string ToString()
        {
            return String.Format("<Line({0}, {1}, {2})", Info, Point1Id, Point2Id);
        }
    }

}
