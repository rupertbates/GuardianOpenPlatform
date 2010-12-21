using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Guardian.OpenPlatform.Results;
using Guardian.OpenPlatform.Results.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System.IO;
using Guardian.OpenPlatform;
using Formatting = Newtonsoft.Json.Formatting;
using Guardian.OpenPlatform.Results.SearchResponses;

namespace Guardian.OpenPlatform.Tests
{
    [TestFixture]
    public class TestSerialization
    {
        [Test]
        public void Can_Deserialize_Gallery()
        {
            var content = File.ReadAllText("Json\\Gallery.json");

            var item = new ObjectDeserializer().Deserialize<ItemResponse>(content).Content;

            Assert.AreEqual("world/gallery/2010/sep/17/pope-benedict-xvi-catholicism", item.Id);
            Assert.AreEqual("Pope Benedict XVI's UK visit: Day two", item.Fields.Headline);
            Assert.AreEqual(13, item.MediaAssets.Count());
            Assert.AreEqual(6, item.Tags.Count());
            Assert.AreEqual("gallery", item.MediaAssets[0].Rel);

            
        }
        [Test]
        public void Can_Deserialize_Search()
        {
            var content = File.ReadAllText("Json\\Results.json");
            var response = new ObjectDeserializer().Deserialize<ContentSearchResponse>(content);
            
            Assert.AreEqual(10, response.Results.Count());
            Assert.AreEqual(response.CurrentPage, 1);
            Assert.AreEqual(response.PageSize, 10);
            Assert.AreEqual(response.Pages, 23);
            Assert.AreEqual(response.Total, 225);
            Assert.AreEqual(response.UserTier, UserTiers.Approved);
            Assert.AreEqual(response.OrderBy, Orders.Relevance);
            
            var article = response.Results[0];
            Assert.AreEqual(2010, article.WebPublicationDate.Year);
            Assert.AreEqual("Joanna Newsom", article.Fields.Headline);
            
        }
        [Test]
        public void Can_Deserialize_Tags()
        {
            var content = File.ReadAllText("Json\\tags.json");

            var response = new ObjectDeserializer().Deserialize<TagSearchResponse>(content);

            Assert.IsNotNull(response.Results);
            Assert.AreEqual(10, response.Results.Count());
            var second = response.Results[1];
            Assert.AreEqual("Dick Vinegar", second.WebTitle);
            Assert.AreEqual("contributor", second.Type);
            Assert.AreEqual("profile/dick-vinegar", second.Id);
            Assert.AreEqual("http://content.guardianapis.com/profile/dick-vinegar", second.ApiUrl);
            Assert.AreEqual("http://www.guardian.co.uk/profile/dick-vinegar", second.WebUrl);

        }
        [Test]
        public void Can_Deserialize_Sections()
        {
            var content = File.ReadAllText("Json\\sections.json");

            var response = new ObjectDeserializer().Deserialize<SectionSearchResponse>(content);

            Assert.IsNotNull(response.Results);
            Assert.AreEqual(40, response.Total  );
            var first = response.Results[0];
            Assert.AreEqual("news", first.Id);
            Assert.AreEqual("News", first.WebTitle);
            Assert.AreEqual("http://www.guardian.co.uk/news", first.WebUrl);
            Assert.AreEqual("http://content.guardianapis.com/news", first.ApiUrl);

        }
        [Test]
        public void Can_Deserialize_Reviews()
        {
            var content = File.ReadAllText("Json\\Reviews.json");

            var response = new ObjectDeserializer().Deserialize<ContentSearchResponse>(content);

            Assert.IsNotNull(response.Results);
            Assert.AreEqual(64472, response.Total);
            var first = response.Results[0];
            Assert.AreEqual("Arise Black Man: the Peter Tosh Story – review", first.WebTitle);
            Assert.AreEqual(null, first.Fields.StarRating);
            
            var second = response.Results[1];
            Assert.AreEqual("AfroCubism – review", second.WebTitle);
            Assert.AreEqual(4, second.Fields.StarRating);

        }
    }
}
