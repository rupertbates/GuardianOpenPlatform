using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Guardian.OpenPlatform;

namespace Guardian.OpenPlatform.Tests
{
    [TestFixture]
    public class TestQueryStringBuilder
    {
        [Test]
        public void Test_No_Parameters_Returns_Empty_String()
        {
            QueryStringBuilder qsb = new QueryStringBuilder();

            Assert.IsEmpty(qsb.GetQueryString());
        }
        [Test]
        public void Test_2_Parameters_Return_Valid_Query_String()
        {
            QueryStringBuilder qsb = new QueryStringBuilder();
            qsb.AddParameter("q", "environment");
            qsb.AddParameter("filter", "uk");

            Assert.AreEqual("?q=environment&filter=uk", qsb.GetQueryString());
        }
        [Test]
        public void Test_Parameter_With_No_Value_Does_Not_Appear_In_Query_String()
        {
            QueryStringBuilder qsb = new QueryStringBuilder();
            qsb.AddParameter("q", "environment");
            qsb.AddParameter("filter", "uk");
            qsb.AddParameter("", "blank");
            qsb.AddParameter(null, "blank");
            qsb.AddParameter("blank", "");
            qsb.AddParameter("", "");
            
            Assert.AreEqual("?q=environment&filter=uk", qsb.GetQueryString());
        }
        [Test]
        public void Test_Format_Date()
        {
            QueryStringBuilder qsb = new QueryStringBuilder();
            DateTime dt = new DateTime(2009, 1, 30);
            Assert.AreEqual("2009-01-30", qsb.FormatDate(dt));
        }
        [Test]
        public void Test_With_Date_Parameter()
        {
            QueryStringBuilder qsb = new QueryStringBuilder();
            qsb.AddParameter("q", "environment");
            qsb.AddParameter("filter", "uk");
            qsb.AddParameter("After", new DateTime(1971, 2, 20));

            Assert.AreEqual("?q=environment&filter=uk&after=1971-02-20", qsb.GetQueryString());
        }
    }
}
