using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.OpenPlatform
{
    internal class AsyncSearchCallbackParameter
    {
        public LoadXmlDelegate Delegate { get; set; }
        public SearchCallback CallbackFunction { get; set; }
    }
}
