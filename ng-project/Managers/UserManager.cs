using ng_project.Entities;
using System;
using System.Collections.Generic;
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
	}
}
