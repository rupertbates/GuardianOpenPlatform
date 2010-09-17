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
                                                  From = new DateTime(1971, 2, 20),
                                                  Query = "cristiano ronaldo"
                                              };

            QueryTranslator opqs = new QueryTranslator();
            var result = new Uri(opqs.Translate(sp));
            
            Assert.AreEqual(_baseUrl.Host, result.Host);
            Assert.IsTrue(result.Query.Contains("q=cristiano%20ronaldo"));
            Assert.IsTrue(result.Query.Contains("from-date=1971-02-20"));
            Assert.IsTrue(result.Query.Contains("api-key=" + _key));
        }
        [Test]
        public void Test_TagSearch_Translate()
        {
            TagSearchParameters sp = new TagSearchParameters { Query = "fish" };

            QueryTranslator opqs = new QueryTranslator();
            var result = new Uri(opqs.Translate(sp));
            
            Assert.AreEqual(_baseUrl.Host, result.Host);
            Assert.IsTrue(result.Query.Contains("q=fish"));
            Assert.IsTrue(result.Query.Contains("api-key=" + ConfigurationManager.AppSettings["ApiKey"]));
        }
        [Test]
        public void Test_ItemSearch_Translate()
        {
            QueryTranslator opqs = new QueryTranslator();
            var result = new Uri(opqs.Translate("tv-and-radio/2010/apr/10/charlie-brooker-mad-men-screenburn"));

            var url = "http://" + _baseUrl.Host + "/tv-and-radio/2010/apr/10/charlie-brooker-mad-men-screenburn?api-key=" + _key;

            Assert.IsTrue(result.AbsoluteUri.Contains(url));
        }
        [Test]
        public void Test_Content_Search_With_Tags_Translate()
        {
            var opqs = new QueryTranslator();
            var sp = new ContentSearchParameters
            {
                From = new DateTime(1971, 2, 20),
                Query = "prince",
                Tags = new List<string> { "music/music", "culture/culture" }
            };
            var result = new Uri(opqs.Translate(sp));

            Assert.IsTrue(result.Query.Contains("q=prince"));
            Assert.IsTrue(result.Query.Contains("from-date=1971-02-20"));
            Assert.IsTrue(result.Query.Contains("tag=music/music,culture/culture"));
            Assert.IsTrue(result.Query.Contains("api-key=" + _key));
        }
        //[Test]
        //public void Test_Content_Search_With_Tags_Translate_Strips_Leading_Slash()
        //{
        //    var opqs = new QueryTranslator();
        //    var sp = new ContentSearchParameters
        //    {
        //        From = new DateTime(1971, 2, 20),
        //        Query = "prince",
        //        Tags = new List<string> { "music/music" }
        //    };
        //    var result = new Uri(opqs.Translate(sp));

        //    Assert.IsTrue(result.Query.Contains("q=prince"));
        //    Assert.IsTrue(result.Query.Contains("after=19710220"));
        //    Assert.IsTrue(result.Query.Contains("filter=/music"));
        //    Assert.IsTrue(result.Query.Contains("api-key=" + _key));
        //}
    }
}
