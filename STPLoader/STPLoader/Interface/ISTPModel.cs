using System;
using System.IO;
using System.Collections.Generic;

namespace STPLoader
{
	public interface IStpModel
	{
		IList<IStpModel> Parts { get;}
	}
}

