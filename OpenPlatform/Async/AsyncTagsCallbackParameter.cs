using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.OpenPlatform
{
    internal class AsyncTagsCallbackParameter
    {
        public LoadXmlDelegate Delegate { get; set; }
        public TagsCallback CallbackFunction { get; set; }
    }
}
