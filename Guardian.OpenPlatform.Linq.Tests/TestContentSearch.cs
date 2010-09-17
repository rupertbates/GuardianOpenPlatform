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
            var query = from c in data
                        where c.WebTitle == "Nina Nastasia"
                        select c;
            var list = query.ToList();
            Assert.IsTrue(query.Count() > 0);
            foreach (var content in query)
            {
                System.Diagnostics.Debug.WriteLine(content.Id);
            }
        }
    }
}
