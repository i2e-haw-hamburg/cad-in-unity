using System;

namespace STPLoader
{
	/// <summary>
	/// STP parser.
	/// </summary>
	class STPParser : IParser
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="STPLoader.STPParser"/> class.
		/// </summary>
		public STPParser ()
		{
		}


		#region IParser implementation
		public ISTPModel Parse (System.IO.Stream stream)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

