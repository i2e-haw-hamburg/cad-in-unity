using STPLoader.Implementation.Parser;

namespace STPLoader.Implementation.Model
{
	class StpFile
	{
		private StpHeader _header;
		private StpData _data;


	    public StpHeader Header
	    {
	        get { return _header; }
            set { _header = value; }
	    }

        public StpData Data
        {
            get { return _data; }
            set { _data = value; }
        }
	}

}

