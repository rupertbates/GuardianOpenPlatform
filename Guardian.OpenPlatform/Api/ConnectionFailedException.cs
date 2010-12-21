using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guardian.OpenPlatform
{
    public class ConnectionFailedException : Exception
    {
        public ConnectionFailedException(string query)
        {
            Query = query;
        }
        public string Query { get; private set; }
    }
}
