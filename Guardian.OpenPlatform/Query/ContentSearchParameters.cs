using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.OpenPlatform
{
    public class ContentSearchParameters
    {
        public ContentSearchParameters()
        {
            TagFilter = new List<string>();
        }
        /// <summary>
        /// A list of tags to filter by
        /// </summary>
        public List<string> TagFilter { get; set; }
        /// <summary>
        /// A List of tag types (eg. keyword) to return in the response, add 'all' for all
        /// </summary>
        public List<string> ShowTags { get; set; }
        /// <summary>
        /// A List of the optional content fields to return in the response, add 'all' for all
        /// </summary>
        public List<string> ShowFields { get; set; }
        public string Query { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        //public string ContentType { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public string Section { get; set; }
    }
}
