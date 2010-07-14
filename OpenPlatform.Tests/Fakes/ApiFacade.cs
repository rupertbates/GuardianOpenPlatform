using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Guardian.OpenPlatform;

namespace Guardian.OpenPlatform.Tests
{

    public class ApiService : IApiService
    {
        protected string _xmlFile;
        public ApiService(string xmlFile)
        {
            _xmlFile = xmlFile;
        }

        #region IApiService Members

        public XmlDocument LoadContent(string query)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_xmlFile);
            return doc;
        }

        #endregion
    }
}
