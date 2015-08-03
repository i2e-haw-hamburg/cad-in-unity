using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using STPLoader.Implementation.Model;

namespace STPLoader.Implementation.Parser
{
    /// <summary>
    /// 
    /// </summary>
	static class ParseHelper
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public static Stream FindSection(Stream stream, string start, string end)
        {
            stream.Position = 0;
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
        /// <param name="stream"></param>
        /// <param name="lineStart"></param>
        /// <returns></returns>
	    public static IList<string> ParseHeaderLine(Stream stream, string lineStart)
        {
            stream.Position = 0;
			var reader = new StreamReader(stream);
			string line;
	        while ((line = reader.ReadLine()) != null)
	        {
	            if (line.StartsWith(lineStart))
	            {
	                var listString = line.Substring(lineStart.Length, line.Length - lineStart.Length - 1);
	                return ParseList(listString);
	            }
	        }

            throw new ParsingException("Can't find "+ lineStart);
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listString"></param>
        /// <returns></returns>
	    public static IList<string> ParseList(string listString)
	    {
            // remove parenthesis
            var inner = listString.Remove(listString.Length - 2).Substring(1);
	        return inner.Split(',');
	    }

        /// <summary>
        /// Parse ISO 8601 date string
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
	    public static DateTime ParseDate(string dateString)
	    {
            DateTime d;
            DateTime.TryParseExact(dateString, "s", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out d);
            
            return d;
	    }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataStream"></param>
        /// <returns></returns>
	    public static IList<string> ParseBody(Stream dataStream)
	    {
            dataStream.Position = 0;
            var reader = new StreamReader(dataStream);
            IList<string> lines = new List<string>();
	        string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

	        return lines;
	    }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
	    public static Entity ParseBodyLine(string line)
	    {
	        var entity = new Entity();
            // remove = from id
	        var splitted = line.Split('=');
	        entity.Id = ParseId(splitted[0]);
	        line = splitted[1].Remove(splitted[1].IndexOf(';')).Trim();
	        var positionOfList = line.IndexOf('(');
            entity.Type = line.Substring(0, positionOfList);
            entity.Data = ParseList(line.Substring(positionOfList));
	        return entity;
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
	    public static int ParseId(string id)
	    {
            return int.Parse(id.Substring(1));
	    }
	}
}

