using Microsoft.EntityFrameworkCore;
using ng_project.Context;
using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ng_project.Managers
{
	public class SubscriberManager :EntityManager<Subscriber,int>
	{
		private static SubscriberManager _instance;
		public static SubscriberManager Instance
		{
			get
			{
				return _instance ?? (_instance = new SubscriberManager());
			}
		}

		public override Subscriber FindById(int id)
		{
			using (var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var model = db.Subscribers
					//.AsNoTracking()
					//.Include(t=> t.Projects)
					//.AsNoTracking()
					//.Include(t=> t.User)
					//.AsNoTracking()
					.FirstOrDefault(t => t.Id == id);
				return model;
			}
		}
	}
}
