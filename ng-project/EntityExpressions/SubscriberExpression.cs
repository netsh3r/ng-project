using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.EntityExpressions
{
	public class SubscriberExpression
	{
		public static Func<object, bool> FindByUserId(int userId)
		{
			return s => (s as Subscriber).UserId == userId;
		}
		public static Expression<Func<Subscriber, object>> UserSubscriber()
		{
			return t => new Subscriber()
			{
				Id = t.Id,
				UserId = t.UserId,
				ProjectSubscribers = t.ProjectSubscribers
			};
		}
	}
}
