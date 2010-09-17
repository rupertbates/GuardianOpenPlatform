using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform.Tests.Fakes;
using NUnit.Framework;
using Guardian.OpenPlatform;

namespace Guardian.OpenPlatform.Tests
{
    [TestFixture]
    public class TestOpenPlatformSearch
    {
        [Test]
        public void Test_Search()
        {
            var op = new OpenPlatformSearch(new ApiService("Json\\ContentSearch.json"));
            var results = op.ContentSearch(new ContentSearchParameters
            {
                Query = "Nina Nastasia",
                PageSize = 20
            });

            Assert.AreEqual(10, results.Results.Count());
            var article = results.Results[0];
            Assert.AreEqual(2004, article.WebPublicationDate.Year);
            

            var video = results.Results[7];
            
        }
        [Test]
        public void Test_Item_Search()
        {
            var op = new OpenPlatformSearch(new ApiService("Json\\Article.json"));
            var item = op.Item("tv-and-radio/2010/apr/10/charlie-brooker-mad-men-screenburn");

            Assert.AreEqual("tv-and-radio/2010/apr/10/charlie-brooker-mad-men-screenburn", item.Id);
            //Assert.AreEqual("article", item.Type);
            Assert.AreEqual("Charlie Brooker", item.Fields.Byline);
            Assert.AreEqual(8, item.Tags.Count());
            Assert.AreEqual(2010, item.WebPublicationDate.Year);
            
        }
        [Test]
        public void Test_Tag_Search()
        {
            var op = new OpenPlatformSearch(new ApiService("Json\\Tags.json"));
            var item = op.Tags(new TagSearchParameters());

            Assert.IsNotNull(item.Results);
            Assert.AreEqual(10, item.Results.Count());
            var second = item.Results[1];
            Assert.AreEqual("Dick Vinegar", second.WebTitle);
            Assert.AreEqual("contributor", second.Type);
            Assert.AreEqual("profile/dick-vinegar", second.Id);
            Assert.AreEqual("http://content.guardianapis.com/profile/dick-vinegar", second.ApiUrl);
            Assert.AreEqual("http://www.guardian.co.uk/profile/dick-vinegar", second.WebUrl);
        }
    }
}
