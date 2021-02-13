using ng_project.Entities;
using System.Collections.Generic;

namespace ng_project.Services
{
	/// <summary>
	/// Базовый сервис проекта для работы с основными данными
	/// </summary>
	public interface INgProjectService
	{
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