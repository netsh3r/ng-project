using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Services
{
	/// <summary>
	/// Базовый сервис
	/// </summary>
	public interface IBaseService<T, IdT>
	{
		IBaseService<T, IdT> GetWithInclude(Expression<Func<T, object>> expression);
		/// <summary>
		/// Найти всех участников
		/// </summary>
		/// <returns></returns>
		ICollection<T> FindAll();
		/// <summary>
		/// Найти всех по условию
		/// </summary>
		/// <param name="func"></param>
		/// <returns></returns>
		ICollection<T> FindAll(Func<T, bool> func);
		ICollection<T> FindAll(Expression<Func<T, object>> expression);
		/// <summary>
		/// Найти сущность по ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		T FindById(IdT id);
		/// <summary>
		/// Найти сущность по особому условию
		/// </summary>
		/// <param name="func"></param>
		/// <returns></returns>
		T FindByFunc(Func<T, bool> func);
		/// <summary>
		/// Сохранить сущность
		/// </summary>
		/// <param name="model"></param>
		void Save(T model);
	}
}
