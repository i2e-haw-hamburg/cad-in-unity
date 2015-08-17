using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STPLoader;

namespace STPConverter
{
    public interface IConverter
    {
        MeshModel Convert(IStpModel model);
    }

}
