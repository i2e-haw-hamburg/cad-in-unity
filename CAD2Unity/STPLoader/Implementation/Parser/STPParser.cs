using System;
using System.IO;
using System.Linq;
using System.Net.Security;
using BasicLoader;
using CADLoader;
using STPLoader.Implementation.Model;

namespace STPLoader.Implementation.Parser
{
    /// <summary>
    /// 
    /// </summary>
    public class StpParser : IParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public IStpModel Parse(Stream stream)
        {
            return new StpFile { Header = ParseHeader(FindHeader(stream)), Data = ParseData(FindData(stream)) };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private Stream FindData(Stream stream)
        {
            var start = "DATA;";
            var end = "ENDSEC;";

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
            var end = "ENDSEC;";

			return ParseHelper.FindSection(stream, start, end);
        }

        IModel IParser.Parse(Stream stream)
        {
            throw new NotImplementedException();
        }

        public CADType CAD => CADType.STP;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataStream"></param>
        /// <returns></returns>
        private StpData ParseData(Stream dataStream)
        {
            try
            {
                var lines = ParseHelper.ParseBody(dataStream);

                var entities = lines.Select(ParseHelper.ParseBodyLine);
                return new StpData(entities.ToDictionary(entity => entity.Id));
            }
            catch (Exception e)
            {
                throw new ParsingException("Error while parsing file. "+e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headerStream"></param>
        /// <returns></returns>
        private StpHeader ParseHeader(Stream headerStream)
        {
			var header = new StpHeader ();
            var descriptionList = ParseHelper.ParseHeaderLine(headerStream, "FILE_DESCRIPTION");
            header.Description = new FileDescription(ParseHelper.ParseList(descriptionList[0]), descriptionList[1]);
            var nameList = ParseHelper.ParseHeaderLine(headerStream, "FILE_NAME");
            header.Name = new FileName(nameList[0], ParseHelper.ParseDate(nameList[1]), 
                ParseHelper.ParseList(nameList[2]), ParseHelper.ParseList(nameList[3]), nameList[4], nameList[5], nameList[6]);
            var schemaList = ParseHelper.ParseHeaderLine(headerStream, "FILE_SCHEMA");
            header.Schema = new FileSchema(ParseHelper.ParseList(schemaList[0]));
			return header;
        }

    }

}