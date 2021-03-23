using Microsoft.EntityFrameworkCore;
using ng_project.Context;
using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ng_project.Managers
{
	public class SkillsManager:EntityManager<Skill,int>
	{
		private static SkillsManager _instance;
		public static SkillsManager Instance
		{
			get
			{
				return _instance ?? (_instance = new SkillsManager());
			}
		}
		public override Skill FindById(int id)
		{
			using(var db = new NgContext())
			{
				var model = db.Skills
					.Include(t => t.Participant)
					.FirstOrDefault(t => t.Id == id);
				return model;
			}
		}

		public List<Skill> FindAllByParticipantId(int participantId)
		{
			using(var db= new NgContext())
			{
				var allSkiillsParticipant = db.SkillsParticipants.
					Include(t => t.Skill).Where(t => t.ParticipantId == participantId).Select(t => t.Skill).ToList();
				return allSkiillsParticipant;
			}
		}
	}
}
