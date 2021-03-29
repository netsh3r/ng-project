using Microsoft.EntityFrameworkCore;
using ng_project.Context;
using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Managers
{
	public class UserManager : EntityManager<User,int>
	{
		private static UserManager _instance;
		public static UserManager Instance
		{
			get
			{
				return _instance ?? (_instance = new UserManager());
			}
		}

		public Expression<Func<User, Worker>> GetEx()
		{
			return null;
		}


		public override User Find(Func<User, bool> expression)
		{
			using(var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				Type project = typeof(Project);
				object tttd = GetEx();
				var user = db.Users
					//.AsNoTracking()
					//.Include(t => t.Email)
					//.AsNoTracking()
					//.Include(t => t.Worker)
					////.AsNoTracking()
					//	.ThenInclude(t => t.Projects)
					////.AsNoTracking()
					//.Include(t => t.Worker)
					//	.ThenInclude(t => t.Skills)
					////.AsNoTracking()
					//.Include(t => t.Subscriber)
					////.AsNoTracking()
					//	.ThenInclude(t => t.Projects)
					////.AsNoTracking()
					//.Include(t => t.Projects)
					//.AsNoTracking()
					//.Include(t => t.Image)
					//.AsNoTracking()
					.FirstOrDefault(expression);
				return user;
			}
		}
		//public override void Save(User entity)
		//{
		//	using (var db = new NgContext())
		//	{
		//		db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		//		db.Users.Update(entity);
		//		db.SaveChangesAsync();
		//	}
		//}
	}
}
