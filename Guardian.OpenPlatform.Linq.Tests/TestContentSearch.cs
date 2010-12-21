using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Guardian.OpenPlatform.Results.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guardian.OpenPlatform.Linq.Tests
{
    [TestClass]
    public class TestContentSearch
    {
        [TestMethod]
        public void Simple_where_clause()
        {
            var data = new QueryableOpenPlatformData<Content>();
            var query = data.Where(c => c.WebTitle == "Nina Nastasia" && c.WebPublicationDate > DateTime.MinValue);
                        
            var list = query.ToList();
            Assert.IsTrue(query.Count() > 0);
            foreach (var content in query)
            {
                System.Diagnostics.Debug.WriteLine(content.Id);
            }
        }
    }
}
