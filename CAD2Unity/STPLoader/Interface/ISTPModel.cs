using System;
using System.IO;
using System.Collections.Generic;
using CADLoader;
using STPLoader.Implementation.Model.Entity;

namespace STPLoader
{
    /// <summary>
    /// 
    /// </summary>
	public interface IStpModel : IModel
    {
        IList<T> All<T>() where T : Entity;
        IDictionary<long, Entity> All();
        Entity Get(long id);
        T Get<T>(long id) where T : Entity;
    }
}

