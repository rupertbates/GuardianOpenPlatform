using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.IO;

namespace Guardian.OpenPlatform
{
    public interface IApiService
    {
        string LoadContent(string query);
    }
    public class ApiFacade : IApiService
    {

        #region IApiService Members

        public string LoadContent(string query)
        {
            var request = (HttpWebRequest)WebRequest.Create(query);
            
            var response = (HttpWebResponse)request.GetResponse();
            if(response == null)
                throw new ConnectionFailedException(query);

            var content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            response.Close();
            return content;
        }

        #endregion
    }
}
