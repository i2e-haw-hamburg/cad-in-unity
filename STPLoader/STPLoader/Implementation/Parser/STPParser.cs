using System;
using System.IO;

namespace STPLoader.Implementation.Parser
{
	/// <summary>
	/// STP parser.
	/// </summary>
	class STPParser : IParser
	{			
		#region IParser implementation
		public ISTPModel Parse (Stream stream)
		{
			throw new NotImplementedException ();
		}
		#endregion
	
	
		private STPFile ParseStructure(Stream stream) {
			var stpFile = new STPFile ();
			stpFile.Header = ParseHeader (FindHeader(stream));
			stpFile.Data = ParseData (FindData (Stream));

			return stpFile;
		}
	}
}

