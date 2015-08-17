using System;
using System.IO;
using System.Collections.Generic;
using STPLoader.Implementation.Model.Entity;

namespace STPLoader
{
    /// <summary>
    /// 
    /// </summary>
	public interface IStpModel
    {
        IList<T> All<T>() where T : Entity;
        IDictionary<long, Entity> All();
        Entity Get(long id);
    }
}

