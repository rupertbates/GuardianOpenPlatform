using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform.Results;
using Guardian.OpenPlatform.Results.Entities;
using Guardian.OpenPlatform.Results.SearchResponses;
using Guardian.OpenPlatform.Tests.Fakes;
using NUnit.Framework;
using System.Threading;

namespace Guardian.OpenPlatform.Tests
{
    [TestFixture]
    public class TestAsync
    {
        public bool callbackFired = false;

        //Search
        [Test]
        public void Test_Async_Search()
        {
            callbackFired = false;
            var op = new OpenPlatformSearch(new ApiService("Json\\ContentSearch.json"));
            op.ContentSearchASync(new ContentSearchParameters
            {
                Query = "Nina Nastasia",
                PageSize = 20
            }, SearchResultsCallback);
            while (!callbackFired)
            {
                Thread.Sleep(500);
            }

        }
        public void SearchResultsCallback(ContentSearchResponse results)
        {
            callbackFired = true;
            Assert.AreEqual(10, results.Results.Count());
            var article = results.Results[0];
            Assert.AreEqual(2004, article.WebPublicationDate.Year);
            //Assert.IsFalse(article.TypeSpecific.DurationMinutesSpecified);

            var video = results.Results[7];
            //Assert.IsTrue(video.TypeSpecific.DurationMinutesSpecified);
            //Assert.AreEqual(7, video.TypeSpecific.DurationMinutes);
            
        }

        //Item
        [Test]
        public void Test_Async_Item_Search()
        {
            callbackFired = false;
            var op = new OpenPlatformSearch(new ApiService("Json\\Article.json"));
            op.ItemASync("tv-and-radio/2010/apr/10/charlie-brooker-mad-men-screenburn", ItemCallback);
            while (!callbackFired)
            {
                Thread.Sleep(500);
            }
            
        }
        public void ItemCallback(Content item)
        {
            callbackFired = true;
            Assert.AreEqual("tv-and-radio/2010/apr/10/charlie-brooker-mad-men-screenburn", item.Id);
            //Assert.AreEqual("article", item.Type);
            Assert.AreEqual("Charlie Brooker", item.Fields.Byline);
            Assert.AreEqual(8, item.Tags.Count());
            Assert.AreEqual(2010, item.WebPublicationDate.Year);

            
        }

        //Tags
        [Test]
        public void Test_Tag_Search()
        {
            var op = new OpenPlatformSearch(new ApiService("Json\\Tags.json"));
            op.TagsASync(new TagSearchParameters(), TagsCallback);
            while (!callbackFired)
            {
                Thread.Sleep(500);
            }

        }
        public void TagsCallback(TagSearchResponse response)
        {
            callbackFired = true;
            Assert.IsNotNull(response.Results);
            Assert.AreEqual(10, response.Results.Count());
            var second = response.Results[1];
            Assert.AreEqual("Dick Vinegar", second.WebTitle);
            Assert.AreEqual("contributor", second.Type);
            Assert.AreEqual("profile/dick-vinegar", second.Id);
            Assert.AreEqual("http://content.guardianapis.com/profile/dick-vinegar", second.ApiUrl);
            Assert.AreEqual("http://www.guardian.co.uk/profile/dick-vinegar", second.WebUrl);
           
        }

    }
}
