using ng_project.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ng_project.Services
{
	public interface IProjectService : IBaseService<Project, int>
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
		void AddSubscribe(int projectId, int subscriberId);
		void AddParticipant(int projectId, int workerId);
	}
}