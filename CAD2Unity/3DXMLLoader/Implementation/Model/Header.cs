using System;

namespace ThreeDXMLLoader.Implementation.Model
{
    /// <summary>
    /// 
    /// </summary>
    class Header
    {
        private string _name;
        private string _schema;
        private string _author;
        private DateTime _created;
    
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Schema
        {
            get
            {
                return _schema;
            }

            set
            {
                _schema = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                _author = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Created
        {
            get
            {
                return _created;
            }

            set
            {
                _created = value;
            }
        }
    }
}
