using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Managers
{
	/// <summary>
	/// Базовый менеджер для работы с данными
	/// </summary>
	interface IBaseEntityManager<T,IdT>
	{
		/// <summary>
		/// Добавить запись в бд
		/// </summary>
		void Add(T entity);
		/// <summary>
		/// Удалить запись из бд
		/// </summary>
		/// <param name="id"></param>
		void Delete(int id);
		/// <summary>
		/// Изменить значение сущности
		/// </summary>
		/// <param name="entity"></param>
		void Save(T entity);
		/// <summary>
		/// Получить сущность по id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		T FindById(int id);
		/// <summary>
		/// Получить все данные из бд
		/// </summary>
		/// <returns></returns>
		ICollection<T> FindAll();
		/// <summary>
		/// Получить данные по условию
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		T Find(Func<T, bool> expression);
	}
}
