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
            Tags = new List<string>();
        }
        public List<string> Tags { get; set; }
        public string Query { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string ContentType { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public string Section { get; set; }
    }
}
