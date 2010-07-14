using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenPlatformDemo;

namespace Guardian.OpenPlatform.Tests.DemoTests
{
    [TestFixture]
    public class TestAuthorController
    {
        [Test]
        public void Controller_Can_Create_Dictionary()
        {
            var op = new OpenPlatformSearch(new Guardian.OpenPlatform.Tests.ApiService("xml\\SearchResults.xml"));
            var results = op.Search(new ContentSearchParameters());
            var countByDay = ResultsHelper.GetCountByDay(results.Results);
            Assert.AreEqual(10, countByDay.First().Value);
        }
    }
}
