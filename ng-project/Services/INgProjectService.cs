using ng_project.Entities;
using System;
using System.Collections.Generic;

namespace ng_project.Services
{
	/// <summary>
	/// Базовый сервис проекта для работы с основными данными
	/// </summary>
	public interface INgProjectService
	{
		/// <summary>
		/// Найти generic объект по условию
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="IdT"></typeparam>
		/// <param name="func"></param>
		/// <returns></returns>
		T FindByFunc<T, IdT>(Func<T, bool> func) where T : Entity<IdT>, new();
		/// <summary>
		/// Сохранить generic объект
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="IdT"></typeparam>
		/// <param name="model"></param>
		void Save<T, IdT>(T model) where T : Entity<IdT>, new();
		/// <summary>
		/// Создать generic объект
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="IdT"></typeparam>
		/// <param name="model"></param>
		void Add<T, IdT>(T model) where T : Entity<IdT>, new();
		/// <summary>
		/// Получить generic объект по ID
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="IdT"></typeparam>
		/// <param name="id"></param>
		/// <returns></returns>
		T GetById<T, IdT>(IdT id) where T : Entity<IdT>, new();
		/// <summary>
		/// Получить все generic объекты с каким-либо условием
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="IdT"></typeparam>
		/// <param name="expression"></param>
		/// <returns></returns>
		ICollection<T> GetAll<T,IdT>(Func<T,bool> expression) where T:Entity<IdT>, new();
		/// <summary>
		/// Получить все generic объекты
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="IdT"></typeparam>
		/// <returns></returns>
		ICollection<T> GetAll<T,IdT>() where T:Entity<IdT>, new();
		/// <summary>
		/// Получить всех юзеров
		/// </summary>
		ICollection<User> GetAllUsers();

		/// <summary>
		/// Получаем user по Id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		User FindUserById(int Id);
		/// <summary>
		/// Добавляем проект в бд
		/// </summary>
		/// <param name="project"></param>
		/// <returns></returns>
		void AddProject(Project project);

	}
}