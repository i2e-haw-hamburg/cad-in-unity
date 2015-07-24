using System;
using System.IO;
using System.Collections.Generic;

namespace STPLoader
{
	/// <summary>
	/// STP model.
	/// </summary>
	class STPModel : ISTPModel
	{
		#region ISTPModel implementation
		public IList<ISTPModel> Parts {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		
	}

}

