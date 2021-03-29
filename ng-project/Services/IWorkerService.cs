using ng_project.Entities;
using System.Collections.Generic;

namespace ng_project.Services
{
	public interface IWorkerService : IBaseService<Worker, int>
	{
		/// <summary>
		/// Получить всех учатсников
		/// </summary>
		/// <returns></returns>
		List<Worker> GetAll();
	}
}