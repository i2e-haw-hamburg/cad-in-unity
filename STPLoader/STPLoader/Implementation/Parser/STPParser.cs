using System.IO;
using System.Linq;
using System.Net.Security;
using STPLoader.Implementation.Model;

namespace STPLoader.Implementation.Parser
{
    /// <summary>
    /// 
    /// </summary>
    public class StpParser : IParser
    {
        public IStpModel Parse(Stream stream)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private StpFile ParseStructure(Stream stream)
        {
            var stpFile = new StpFile();

            stpFile.Header = ParseHeader(FindHeader(stream));
            stpFile.Data = ParseData(FindData(stream));

            return stpFile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private Stream FindData(Stream stream)
        {
            var start = "DATA;";
            var end = "ENDSEC";

            return FindSection(stream, start, end);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private Stream FindHeader(Stream stream)
        {
            var start = "HEADER;";
            var end = "ENDSEC";

            return FindSection(stream, start, end);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private Stream FindSection(Stream stream, string start, string end)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            var reader = new StreamReader(stream);
            string line;
            var inSection = false;
            
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Equals(start))
                {
                    inSection = true;
                    continue;
                }
                if (line.Equals(end))
                {
                    inSection = false;
                    continue;
                }
                if (inSection)
                {
                    sw.WriteLine(line);
                }
            }
            sw.Flush();

            return ms;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataStream"></param>
        /// <returns></returns>
        private StpData ParseData(Stream dataStream)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headerStream"></param>
        /// <returns></returns>
        private StpHeader ParseHeader(Stream headerStream)
        {
            throw new System.NotImplementedException();
        }
    }

}