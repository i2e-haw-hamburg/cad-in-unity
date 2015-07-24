using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STPLoader.Implementation.Model
{
    class FileName
    {
        private string Name { get; set; }
        private DateTime TimeStamp { get; set; }
        private string Author { get; set; }
        private string Organization { get; set; }
        private string PreprocessorVersion { get; set; }
        private string OriginatingSystem { get; set; }
        private string Authorization { get; set; }
    }
}
