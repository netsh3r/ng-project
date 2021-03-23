using ng_project.Entities;
using System.Collections.Generic;

namespace ng_project.Services
{
	public interface ISkillService
	{
		Skill Find(int id);

		List<Skill> FindAllByParticipantId(int participantId);
	}
}