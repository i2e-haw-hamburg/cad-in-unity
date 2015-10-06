using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicLoader;

namespace CADLoader
{
    public class CADLoader
    {
        private IDictionary<CADType, IParser> _parsers;

        public CADLoader(IList<IParser> parsers)
        {
            _parsers = parsers.ToDictionary(x => x.CAD);
        }

        public IModel Load(CADType c, ILoader loader)
        {
            if (_parsers.ContainsKey(c))
            {
                return _parsers[c].Parse(loader.Load());
            }
            throw new Exception("Can't parse given type.");
        }

        
    }
}
