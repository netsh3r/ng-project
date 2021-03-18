using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Services
{
	public interface IUserService
	{
		/// <summary>
		/// Авторизоваться
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		User Login(Func<User, bool> expression);
		/// <summary>
		/// Зарегистрировать пользователя
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		void Registry(User user);
		User FindUser(Func<User, bool> expression);
		void Save(User user);
	}
}
