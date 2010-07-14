using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using NUnit.Framework;
using System.IO;
using Guardian.OpenPlatform;
namespace Guardian.OpenPlatform.Tests
{
    [TestFixture]
    public class TestSerialization
    {
        [Test]
        public void Can_Deserialize_Gallery_Xml()
        {
            var doc = new XmlDocument();
            doc.Load("xml\\gallery.xml");

            var item = new ObjectDeserializer().Deserialize<Content>(doc.OuterXml);

            Assert.AreEqual(344089365, item.Id);
            Assert.AreEqual("gallery", item.Type);
            Assert.AreEqual(6, item.TaggedWith.Count());
            Assert.AreEqual(16, item.TypeSpecific.PictureCount);

            
        }
        [Test]
        public void Can_Deserialize_Article_Xml()
        {
            var doc = new XmlDocument();
            doc.Load("xml\\article.xml");

            var item = new ObjectDeserializer().Deserialize<Content>(doc.OuterXml);

            Assert.AreEqual(353757375, item.Id);
            Assert.AreEqual("article", item.Type);
            Assert.AreEqual("Charlie Brooker", item.Byline);
            Assert.AreEqual(6, item.TaggedWith.Count());
            Assert.AreEqual(2009, item.PublicationDate.Year);
            Assert.IsNotEmpty(item.TypeSpecific.Body);


        }
        [Test]
        public void Can_Deserialize_Search_Xml()
        {
            var doc = new XmlDocument();
            doc.Load("xml\\searchresults.xml");

            var item = new ObjectDeserializer().Deserialize<SearchResults>(doc.OuterXml);

            Assert.AreEqual(10, item.Results.Count());
            var article = item.Results[0];
            Assert.AreEqual(2009, article.PublicationDate.Year);
            Assert.IsFalse(article.TypeSpecific.DurationMinutesSpecified);

            var video = item.Results[7];
            Assert.IsTrue(video.TypeSpecific.DurationMinutesSpecified);
            Assert.AreEqual(7, video.TypeSpecific.DurationMinutes);
            
        }
        [Test]
        public void Can_Deserialize_Tags_Xml()
        {
            var doc = new XmlDocument();
            doc.Load("xml\\tags.xml");

            var item = new ObjectDeserializer().Deserialize<TagResults>(doc.OuterXml);

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
