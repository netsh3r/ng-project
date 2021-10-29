using ng_project.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ng_project.Managers
{
	/// <summary>
	/// Интерфейс для получения вложенных сущностей
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="IdT"></typeparam>
	public interface IIncludeService<T,IdT>
	{
		/// <summary>
		/// Найти все сущности, вместе с вложенными
		/// </summary>
		/// <param name="expEntity"></param>
		/// <returns></returns>
		List<T> FindAll(Expression<Func<T, object>> expEntity);

		/// <summary>
		/// Найти все сущности, вместе с вложенными с условиями
		/// </summary>
		/// <param name="expEntity"></param>
		/// <returns></returns>
		//ICollection<T> FindAll(Func<T, bool> func, List<ExpressionEntity> expEntity);

		///// <summary>
		///// Найти сущность с вложенниями
		///// </summary>
		///// <param name="expEntity"></param>
		///// <returns></returns>
		//T Find(List<ExpressionEntity> expEntity);

		///// <summary>
		///// Найти сущность с вложениями и условиями
		///// </summary>
		///// <param name="func"></param>
		///// <param name="expEntity"></param>
		///// <returns></returns>
		//T Find(Func<T, bool> func, List<ExpressionEntity> expEntity);
	}
}