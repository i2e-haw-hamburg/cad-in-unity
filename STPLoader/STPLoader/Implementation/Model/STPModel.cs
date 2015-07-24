using System;
using System.IO;
using System.Collections.Generic;

namespace STPLoader.Implementation.Model
{
	/// <summary>
	/// STP model.
	/// </summary>
	class STPModel : IStpModel
	{
		#region ISTPModel implementation
		public IList<IStpModel> Parts {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		
	}

}

