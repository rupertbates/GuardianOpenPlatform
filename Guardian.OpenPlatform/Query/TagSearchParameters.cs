using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.OpenPlatform
{
    public class TagSearchParameters
    {
        public string Query { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
    }
}
