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

			return ParseHelper.FindSection(stream, start, end);
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

			return ParseHelper.FindSection(stream, start, end);
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