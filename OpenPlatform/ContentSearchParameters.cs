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
            Filters = new List<string>();
        }
        public string Query { get; set; }
        public DateTime? After { get; set; }
        public DateTime? Before { get; set; }
        public string ContentType { get; set; }
        public int? Count { get; set; }
        public int? StartIndex { get; set; }
        public List<String> Filters { get; set; }
    }
}
