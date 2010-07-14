using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Guardian.OpenPlatform
{
    public interface IApiService
    {
        XmlDocument LoadContent(string query);
    }
    public class ApiFacade : IApiService
    {

        #region IApiService Members

        public XmlDocument LoadContent(string query)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(query);
            return doc;
        }

        #endregion
    }
}
