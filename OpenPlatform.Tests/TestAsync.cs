using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var op = new OpenPlatformSearch(new Guardian.OpenPlatform.Tests.ApiService("xml\\SearchResults.xml"));
            op.SearchASync(new ContentSearchParameters
            {
                Query = "Nina Nastasia",
                Count = 20
            }, SearchResultsCallback);
            while (!callbackFired)
            {
                Thread.Sleep(500);
            }

        }
        public void SearchResultsCallback(SearchResults results)
        {
            Assert.AreEqual(10, results.Results.Count());
            var article = results.Results[0];
            Assert.AreEqual(2009, article.PublicationDate.Year);
            Assert.IsFalse(article.TypeSpecific.DurationMinutesSpecified);

            var video = results.Results[7];
            Assert.IsTrue(video.TypeSpecific.DurationMinutesSpecified);
            Assert.AreEqual(7, video.TypeSpecific.DurationMinutes);
            callbackFired = true;
        }

        //Item
        [Test]
        public void Test_Async_Item_Search()
        {
            callbackFired = false;
            var op = new OpenPlatformSearch(new Guardian.OpenPlatform.Tests.ApiService("xml\\Article.xml"));
            op.ItemASync(353757375, ItemCallback);
            while (!callbackFired)
            {
                Thread.Sleep(500);
            }
            
        }
        public void ItemCallback(Content item)
        {
            Assert.AreEqual(353757375, item.Id);
            Assert.AreEqual("article", item.Type);
            Assert.AreEqual("Charlie Brooker", item.Byline);
            Assert.AreEqual(6, item.TaggedWith.Count());
            Assert.AreEqual(2009, item.PublicationDate.Year);
            Assert.IsNotEmpty(item.TypeSpecific.Body);

            callbackFired = true;
        }

        //Tags
        [Test]
        public void Test_Tag_Search()
        {
            var op = new OpenPlatformSearch(new Guardian.OpenPlatform.Tests.ApiService("xml\\Tags.xml"));
            op.TagsASync(new TagSearchParameters(), TagsCallback);
            while (!callbackFired)
            {
                Thread.Sleep(500);
            }

        }
        public void TagsCallback(TagResults results)
        {
            Assert.IsNotNull(results.Tags);
            Assert.AreEqual(10, results.Tags.Count());
            var first = results.Tags[0];
            Assert.AreEqual("Pope Benedict XVI", first.Name);
            Assert.AreEqual("keyword", first.Type);
            Assert.AreEqual("/world/pope-benedict-xvi", first.Filter);
            Assert.AreEqual("http://api.guardianapis.com/content/search?filter=/world/pope-benedict-xvi", first.ApiUrl);
            Assert.AreEqual("http://www.guardian.co.uk/world/pope-benedict-xvi", first.WebUrl);
            callbackFired = true;
        }

    }
}
