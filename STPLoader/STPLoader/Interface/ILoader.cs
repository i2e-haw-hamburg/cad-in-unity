using System;
using System.IO;

namespace STPLoader
{
	public interface ILoader
	{
		Stream Load();
	}
}

