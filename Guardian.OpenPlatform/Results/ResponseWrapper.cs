using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform.Results.Entities;
using Guardian.OpenPlatform.Results.SearchResponses;

namespace Guardian.OpenPlatform.Results
{
    internal class ResponseWrapper<T> where T : ResponseBase
    {
        public T Response { get; set; }
    }
}
