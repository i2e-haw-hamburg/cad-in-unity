using System;
using System.Collections.Generic;

namespace STPLoader.Implementation.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class StpFile : IStpModel
	{
        /// <summary>
        /// 
        /// </summary>
		private StpHeader _header;
        /// <summary>
        /// 
        /// </summary>
		private StpData _data;

        /// <summary>
        /// 
        /// </summary>
	    public StpHeader Header
	    {
	        get { return _header; }
            set { _header = value; }
	    }

        /// <summary>
        /// 
        /// </summary>
        public StpData Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public override string ToString()
        {
            return String.Format("<StpFile({0}, {1})>", Header, Data);
        }

        public IList<T> All<T>() where T : Entity.Entity
        {
            return _data.All<T>();
        }

        public IDictionary<long, Entity.Entity> All()
        {
            return _data.All();
        }

        public Entity.Entity Get(long id)
        {
            return _data.Get(id);
        }
	}

}

