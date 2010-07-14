using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Guardian.OpenPlatform;
using System.Configuration;

namespace Guardian.OpenPlatform.Tests
{
    [TestFixture]
    public class TestQueryGeneration
    {
        Uri _baseUrl;
        string _key;
        [TestFixtureSetUp]
        public void Setup()
        {
            _baseUrl = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
            _key = ConfigurationManager.AppSettings["ApiKey"];
        }
        [Test]
        public void Test_ContentSearch_Translate()
        {
            ContentSearchParameters sp = new ContentSearchParameters
                                              {
                                                  After = new DateTime(1971, 2, 20),
                                                  Query = "cristiano ronaldo"
                                              };

            QueryTranslator opqs = new QueryTranslator();
            var result = new Uri(opqs.Translate(sp));
            
            Assert.AreEqual(_baseUrl.Host, result.Host);
            Assert.IsTrue(result.Query.Contains("q=cristiano%20ronaldo"));
            Assert.IsTrue(result.Query.Contains("after=19710220"));
            Assert.IsTrue(result.Query.Contains("api_key=" + _key));
        }
        [Test]
        public void Test_TagSearch_Translate()
        {
            TagSearchParameters sp = new TagSearchParameters { Query = "fish" };

            QueryTranslator opqs = new QueryTranslator();
            var result = new Uri(opqs.Translate(sp));
            
            Assert.AreEqual(_baseUrl.Host, result.Host);
            Assert.IsTrue(result.Query.Contains("q=fish"));
            Assert.IsTrue(result.Query.Contains("api_key=" + ConfigurationManager.AppSettings["ApiKey"]));
        }
        [Test]
        public void Test_ItemSearch_Translate()
        {
            QueryTranslator opqs = new QueryTranslator();
            var result = new Uri(opqs.Translate(344089365));

            var url = "http://" + _baseUrl.Host + "/content/item/344089365?api_key=" + _key;

            Assert.AreEqual(result, url);
        }
        [Test]
        public void Test_Content_Search_With_Filters_Translate()
        {
            var opqs = new QueryTranslator();
            var sp = new ContentSearchParameters
            {
                After = new DateTime(1971, 2, 20),
                Query = "prince",
                Filters = new List<string>{"music"}
            };
            var result = new Uri(opqs.Translate(sp));

            Assert.IsTrue(result.Query.Contains("q=prince"));
            Assert.IsTrue(result.Query.Contains("after=19710220"));
            Assert.IsTrue(result.Query.Contains("filter=/music"));
            Assert.IsTrue(result.Query.Contains("api_key=" + _key));
        }
        [Test]
        public void Test_Content_Search_With_Filters_Translate_Strips_Leading_Slash()
        {
            var opqs = new QueryTranslator();
            var sp = new ContentSearchParameters
            {
                After = new DateTime(1971, 2, 20),
                Query = "prince",
                Filters = new List<string> { "/music" }
            };
            var result = new Uri(opqs.Translate(sp));

            Assert.IsTrue(result.Query.Contains("q=prince"));
            Assert.IsTrue(result.Query.Contains("after=19710220"));
            Assert.IsTrue(result.Query.Contains("filter=/music"));
            Assert.IsTrue(result.Query.Contains("api_key=" + _key));
        }
    }
}
