using ng_project.Entities;
using ng_project.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Services
{
	public class SkillService:MainService<Skill,int>, ISkillService
	{
		private static SkillService _instance;
		public static SkillService Instance
		{
			get
			{
				return _instance ?? (_instance = new SkillService());
			}
		}
		public SkillService()
		{
			this.skillsManager = SkillsManager.Instance;
		}
		private SkillsManager skillsManager { get; set; }

		public Skill Find(int id)
		{
			return skillsManager.FindById(id);
		}

		public List<Skill> FindAllByParticipantId(int participantId)
		{
			return skillsManager.FindAllByParticipantId(participantId);
		}
	}
}
