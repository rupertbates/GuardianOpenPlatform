using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml;
using System.Configuration;

namespace Guardian.OpenPlatform.Tests
{
    [TestFixture]
    public class TestApi
    {
        private	 string _apiUrl;
		private string _apiKey;
		public TestApi()
		{
			_apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

			if (string.IsNullOrEmpty(_apiUrl))
				throw new ConfigurationErrorsException("The ApiUrl config setting is missing");

			_apiKey = ConfigurationManager.AppSettings["ApiKey"];
			if (string.IsNullOrEmpty(_apiKey))
				throw new ConfigurationErrorsException("The ApiKey config setting is missing");
		}
        [Test]
        //[Ignore]
        public void Can_Get_Results_From_Live_API()
        {
            string url = string.Format("{0}search?&api-key={1}", _apiUrl, _apiKey);
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            Assert.IsNotEmpty(doc.OuterXml);
        }
        [Test]
        public void Can_Get_Results_From_Live_OpenPlatformSearch()
        {
            var op =new OpenPlatformSearch();
            var results = op.Search(new ContentSearchParameters { Query = "Fats Domino" });
            Assert.Greater(results.Results.Count(), 0);
        }
    }
}
