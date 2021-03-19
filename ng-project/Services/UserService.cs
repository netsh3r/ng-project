using ng_project.Entities;
using ng_project.Managers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Services
{
	public class UserService : IUserService
	{
		private static UserService _instance;
		public static UserService Instance
		{
			get
			{
				return _instance ?? (_instance = new UserService());
			}
		}
		private UserManager userManager;
		public UserService()
		{
			userManager = UserManager.Instance;
		}
		public User FindUser(Func<User, bool> expression)
		{
			return userManager.Find(expression);
		}

		public User Login(Func<User, bool> expression)
		{
			return userManager.Find(expression);
		}

		public void Registry(User user)
		{
			userManager.Add(user);
		}

		public void Save(User user)
		{
			userManager.Edit(user);
		}
	}
}
