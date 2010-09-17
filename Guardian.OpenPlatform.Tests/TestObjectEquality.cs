using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform.Results;
using Guardian.OpenPlatform.Results.Entities;
using NUnit.Framework;

namespace Guardian.OpenPlatform.Tests
{
	[TestFixture]
	public class TestObjectEquality
	{
		[Test]
		public void Test_tag_equality()
		{
			Tag t1 = new Tag { Id = "/Rupert" };
			Tag t2 = new Tag { Id = "/Rupert" };
			Tag t3 = new Tag { Id = "/Harry" };
			Tag t4 = t3;
			Assert.AreEqual(t1, t2);
			Assert.AreNotEqual(t1, t3);
			Assert.AreNotSame(t1, t2);
			Assert.AreSame(t3, t4);
		}
		[Test]
		public void Test_tag_equality_IEnumerable()
		{
			var list1 = new List<Tag> { new Tag { Id = "/Rupert" } };
			var list2 = new List<Tag> { new Tag { Id = "/Rupert" } };
			//the intersections of these lists should have 1 element in it
			Assert.Greater(list1.Intersect(list2).Count(), 0);
			//list2 should contain the first element of list1
			Assert.Contains(list1[0], list2);
		}
		[Test]
		public void Test_content_equality()
		{
			Content t1 = new Content { Id = "1" };
			Content t2 = new Content { Id = "1" };
			Content t3 = new Content { Id = "2" };
			Content t4 = t3;
			Assert.AreEqual(t1, t2);
			Assert.AreNotEqual(t1, t3);
			Assert.AreNotSame(t1, t2);
			Assert.AreSame(t3, t4);
		}
		[Test]
		public void Test_equality_IEnumerable()
		{
			var list1 = new List<Content> { new Content { Id = "1"} };
			var list2 = new List<Content> { new Content { Id = "1" } };
			//the intersections of these lists should have 1 element in it
			Assert.Greater(list1.Intersect(list2).Count(), 0);
		}
	}
}
