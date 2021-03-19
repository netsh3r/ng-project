using ng_project.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ng_project.Services
{
	public interface IProjectService
	{

		/// <summary>
		/// Найти проект по id
		/// </summary>
		/// <returns></returns>
		Project FindById(int id);
		/// <summary>
		/// Получить все проекты
		/// </summary>
		/// <returns></returns>
		ICollection<Project> GetAll();
		ICollection<Project> GetAll(Func<Project, bool> expression);
	}
}