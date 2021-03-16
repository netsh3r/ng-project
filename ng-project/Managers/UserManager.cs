using Microsoft.EntityFrameworkCore;
using ng_project.Context;
using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
		public override User Find(Func<User, bool> expression)
		{
			using(var db = new NgContext())
			{
				var user = db.Users.Include(t => t.Email)
					.Include(t=> t.Participant)
					.Include(t=> t.Participant.Skills)
					.FirstOrDefault(expression);
				return user;
			}
		}
		public override void Edit(User entity)
		{
			using (var db = new NgContext())
			{
				db.Users.Update(entity);
				db.SaveChangesAsync();
			}
		}
	}
}
