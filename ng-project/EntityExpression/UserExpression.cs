using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.EntityExpression
{
	public class UserExpression
	{
		public static Func<object,bool> FindByLogin(string login)
		{
			return t => (t as User).login == login;
		}
		public static Expression<Func<User,object>> Main()
		{				
			return t => new User
			{
				Id = t.Id,
				FirstName = t.FirstName,
				LastName = t.LastName,
				Email = t.Email,
				CreationDate = t.CreationDate,
				Creator = t.Creator,
				Image = t.Image,
				login = t.login,
				Password = t.Password,
				Projects = t.Projects
			}; ;
		}
	}
}
