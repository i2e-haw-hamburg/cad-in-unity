using System;
using System.IO;
using System.Collections.Generic;

namespace STPLoader
{
	public interface ISTPModel
	{
		IList<ISTPModel> Parts { get;}
	}
}

