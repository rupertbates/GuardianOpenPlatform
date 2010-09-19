using System;
using System.Linq.Expressions;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Guardian.OpenPlatform.Results.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Guardian.OpenPlatform.Linq.Generic;

namespace Guardian.OpenPlatform.Linq.Tests
{
    [TestClass]
    public class TestQueryVisitor
    {
        [TestMethod]
        public void TestMethod1()
        {
            var vis = new ContentQueryVisitor();
            var context = new OpenPlatformQueryContext();
            //Expression ex = 
            //vis.Translate();
        }
    }
}
