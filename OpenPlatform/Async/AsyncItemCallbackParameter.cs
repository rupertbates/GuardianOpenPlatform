using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.OpenPlatform
{
    internal class AsyncItemCallbackParameter
    {
        public LoadXmlDelegate Delegate { get; set; }
        public ItemCallback CallbackFunction { get; set; }
    }
}
