using ng_project.Entities;
using ng_project.Managers;
using ng_project.SDK;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Services
{
	[Service]
	public class UserService : MainService<User,int>, IUserService
	{
		public UserService()
		{
			userManager = UserManager.Instance;
		}
		private UserManager userManager;

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

		//public void Save(User user)
		//{
		//	userManager.Save(user);
		//}
	}
}
