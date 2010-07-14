using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.OpenPlatform
{
    public class TagSearchParameters
    {
        public string Query { get; set; }
        public int? Count { get; set; }
        public int? StartIndex { get; set; }
    }
}
