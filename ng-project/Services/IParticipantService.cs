using ng_project.Entities;
using System.Collections.Generic;

namespace ng_project.Services
{
	public interface IParticipantService
	{
		/// <summary>
		/// Получить всех учатсников
		/// </summary>
		/// <returns></returns>
		List<Participant> GetAll();
	}
}