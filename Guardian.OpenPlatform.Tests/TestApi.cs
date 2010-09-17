using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml;
using System.Configuration;
using Guardian.Configuration;

namespace Guardian.OpenPlatform.Tests
{
    [TestFixture]
    public class TestApi
    {
        private	 string _apiUrl;
		private string _apiKey;
		public TestApi()
		{
		    _apiUrl = ConfigurationHelper.GetConfigValue("ApiUrl");
            _apiKey = ConfigurationHelper.GetConfigValue("ApiKey");
		}
        [Test]
        [Ignore]
        public void Can_Get_Results_From_Live_API()
        {
            string url = string.Format("{0}search?&api-key={1}&format=xml", _apiUrl, _apiKey);
            var content = new ApiFacade().LoadContent(url);
            Assert.IsNotEmpty(content);
        }
        [Test]
        [Ignore]
        public void Can_Get_Results_From_Live_OpenPlatformSearch()
        {
            var op =new OpenPlatformSearch();
            var results = op.ContentSearch(new ContentSearchParameters { Query = "joanna newsom" });
            Assert.Greater(results.Results.Count(), 0);
        }
    }
}
