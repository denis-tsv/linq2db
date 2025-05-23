﻿using System.Linq;

using NUnit.Framework;

using Tests.Model;

namespace Tests.Samples
{
	[TestFixture]
	public class JoinOperatorTests : TestBase
	{
		[Test]
		public void InnerJoinOnSingleColumn([NorthwindDataContext] string context)
		{
			using (var db = new NorthwindDB(context))
			{
				var query =
					from c in db.Category
					join p in db.Product on c.CategoryID equals p.CategoryID
					where !p.Discontinued
					select c;

				query.ToArray();
			}
		}

		[Test]
		public void InnerJoinOnMultipleColumns([NorthwindDataContext] string context)
		{
			using (var db = new NorthwindDB(context))
			{
				var query =
					from p in db.Product
					from o in db.Order
					join d in db.OrderDetail
						on     new { p.ProductID, o.OrderID }
						equals new { d.ProductID, d.OrderID }
					select new
					{
						p.ProductID,
						o.OrderID,
					};

				var data = query.ToArray();
				Assert.That(data, Is.Not.Empty);
			}
		}
	}
}
