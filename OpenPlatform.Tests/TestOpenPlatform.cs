using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var op = new OpenPlatformSearch(new Guardian.OpenPlatform.Tests.ApiService("xml\\SearchResults.xml"));
            var results = op.Search(new ContentSearchParameters
            {
                Query = "Nina Nastasia",
                Count = 20
            });

            Assert.AreEqual(10, results.Results.Count());
            var article = results.Results[0];
            Assert.AreEqual(2009, article.PublicationDate.Year);
            Assert.IsFalse(article.TypeSpecific.DurationMinutesSpecified);

            var video = results.Results[7];
            Assert.IsTrue(video.TypeSpecific.DurationMinutesSpecified);
            Assert.AreEqual(7, video.TypeSpecific.DurationMinutes);
        }
        [Test]
        public void Test_Item_Search()
        {
            var op = new OpenPlatformSearch(new Guardian.OpenPlatform.Tests.ApiService("xml\\Article.xml"));
            var item = op.Item(353757375);

            Assert.AreEqual(353757375, item.Id);
            Assert.AreEqual("article", item.Type);
            Assert.AreEqual("Charlie Brooker", item.Byline);
            Assert.AreEqual(6, item.TaggedWith.Count());
            Assert.AreEqual(2009, item.PublicationDate.Year);
            Assert.IsNotEmpty(item.TypeSpecific.Body);
        }
        [Test]
        public void Test_Tag_Search()
        {
            var op = new OpenPlatformSearch(new Guardian.OpenPlatform.Tests.ApiService("xml\\Tags.xml"));
            var item = op.Tags(new TagSearchParameters());

            Assert.IsNotNull(item.Tags);
            Assert.AreEqual(10, item.Tags.Count());
            var first = item.Tags[0];
            Assert.AreEqual("Pope Benedict XVI", first.Name);
            Assert.AreEqual("keyword", first.Type);
            Assert.AreEqual("/world/pope-benedict-xvi", first.Filter);
            Assert.AreEqual("http://api.guardianapis.com/content/search?filter=/world/pope-benedict-xvi", first.ApiUrl);
            Assert.AreEqual("http://www.guardian.co.uk/world/pope-benedict-xvi", first.WebUrl);
        }
    }
}
