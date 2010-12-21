using System.Xml;
using System.IO;

namespace Guardian.OpenPlatform.Tests.Fakes
{

    public class ApiService : IApiService
    {
        protected string _file;
        public ApiService(string file)
        {
            _file = file;
        }

        #region IApiService Members

        public string LoadContent(string query)
        {
            return File.ReadAllText(_file);
        }

        #endregion
    }
}
