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
            
            Dummy(c => c.WebTitle == "Nina Nastasia");
            //DummyWhere(q => q.Where(c => c.WebTitle == "Nina Nastasia"));
            
        }
        protected void Dummy(Expression<Func<Content, bool>> expr)
        {
            var vis = new ContentQueryVisitor();
            vis.Translate(expr);
        }
        protected void DummyWhere(Expression<Func<IQueryable<Content>, Expression<Func<Content, bool>>, IQueryable<Content>>> expr)
        {
            var vis = new ContentQueryVisitor();
            vis.Translate(expr);
        }
        
    }
}
