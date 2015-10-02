using System;
using System.IO;

namespace STPLoader
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILoader
	{
		/// <summary>
		/// Load this instance.
		/// </summary>
		/// <returns></returns>
		Stream Load();
	}
}

