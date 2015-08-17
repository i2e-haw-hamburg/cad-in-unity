using System;
using System.Collections.Generic;

namespace STPLoader.Implementation.Model
{
    public class FileName
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="author"></param>
        /// <param name="organization"></param>
        /// <param name="preVersion"></param>
        /// <param name="originSystem"></param>
        /// <param name="authorization"></param>
        public FileName(string name, DateTime date, IList<string> author, IList<string> organization, string preVersion, string originSystem, string authorization)
        {
            Name = name;
            TimeStamp = date;
            Author = author;
            Organization = organization;
            PreprocessorVersion = preVersion;
            OriginatingSystem = originSystem;
            Authorization = authorization;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<string> Author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<string> Organization { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PreprocessorVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OriginatingSystem { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Authorization { get; set; }

        public override string ToString()
        {
            return String.Format("<FileName({0}, {1}, {2}, {3}, {4}, {5}, {6})>", Name, TimeStamp, Author, Organization, PreprocessorVersion, OriginatingSystem, Authorization);
        }
    }
}
