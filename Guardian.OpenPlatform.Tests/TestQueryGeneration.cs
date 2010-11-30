using System;
using System.Collections.Generic;
using Guardian.Configuration;
using NUnit.Framework;

namespace Guardian.OpenPlatform.Tests
{
    [TestFixture]
    public class TestQueryGeneration
    {
        private Uri _baseUrl;
        private string _key;

        [TestFixtureSetUp]
        public void Setup()
        {
            _baseUrl = new Uri(ConfigurationHelper.GetConfigValue("ApiUrl"));
            _key = ConfigurationHelper.GetConfigValueOrDefault("ApiKey", "");
        }

        [Test]
        public void Test_ContentSearch_Translate()
        {
            var sp = new ContentSearchParameters
                         {
                             From = new DateTime(1971, 2, 20),
                             Query = "cristiano ronaldo"
                         };

            var opqs = new QueryTranslator();
            var result = new Uri(opqs.Translate(sp));

            Assert.AreEqual(_baseUrl.Host, result.Host);
            Assert.IsTrue(result.Query.Contains("q=cristiano%20ronaldo"));
            Assert.IsTrue(result.Query.Contains("from-date=1971-02-20"));
            Assert.IsTrue(result.Query.Contains("api-key=" + _key));
        }

        [Test]
        public void Test_Content_Search_With_TagFilter_Translate()
        {
            var opqs = new QueryTranslator();
            var sp = new ContentSearchParameters
                         {
                             From = new DateTime(1971, 2, 20),
                             Query = "prince",
                             TagFilter = new List<string> {"music/music", "culture/culture"}
                         };
            var result = new Uri(opqs.Translate(sp));

            Assert.IsTrue(result.Query.Contains("q=prince"));
            Assert.IsTrue(result.Query.Contains("from-date=1971-02-20"));
            Assert.IsTrue(result.Query.Contains("tag=music/music,culture/culture"));
            Assert.IsTrue(result.Query.Contains("api-key=" + _key));
        }
        [Test]
        public void Test_Content_Search_With_ShowTags_and_ShowFields_Translate()
        {
            var opqs = new QueryTranslator();
            var sp = new ContentSearchParameters
            {
                From = new DateTime(1971, 2, 20),
                Query = "prince",
                ShowTags = new List<string>{"all"},
                ShowFields= new List<string>{"body,star-rating"}
            };
            var result = new Uri(opqs.Translate(sp));

            Assert.IsTrue(result.Query.Contains("q=prince"));
            Assert.IsTrue(result.Query.Contains("from-date=1971-02-20"));
            Assert.IsTrue(result.Query.Contains("show-tags=all"));
            Assert.IsTrue(result.Query.Contains("show-fields=body,star-rating"));
            Assert.IsTrue(result.Query.Contains("api-key=" + _key));
        }

        [Test]
        public void Test_ItemSearch_Translate()
        {
            var opqs = new QueryTranslator();
            var result = new Uri(opqs.Translate("tv-and-radio/2010/apr/10/charlie-brooker-mad-men-screenburn"));

            string url = "http://" + _baseUrl.Host +
                         "/tv-and-radio/2010/apr/10/charlie-brooker-mad-men-screenburn?api-key=" + _key;

            Assert.IsTrue(result.AbsoluteUri.Contains(url));
        }

        [Test]
        public void Test_TagSearch_Translate()
        {
            var sp = new TagSearchParameters {Query = "fish"};

            var opqs = new QueryTranslator();
            var result = new Uri(opqs.Translate(sp));

            Assert.AreEqual(_baseUrl.Host, result.Host);
            Assert.IsTrue(result.Query.Contains("q=fish"));
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
        //        TagFilter = new List<string> { "music/music" }
        //    };
        //    var result = new Uri(opqs.Translate(sp));

        //    Assert.IsTrue(result.Query.Contains("q=prince"));
        //    Assert.IsTrue(result.Query.Contains("after=19710220"));
        //    Assert.IsTrue(result.Query.Contains("filter=/music"));
        //    Assert.IsTrue(result.Query.Contains("api-key=" + _key));
        //}
    }
}