using System;
using System.IO;

namespace STPLoader
{
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
	}
}

