using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	public class Skill:Entity<int>
	{
		public string Name { get; set; }
		public List<SkillsParticipant> Participant { get; set; } = new List<SkillsParticipant>();
	}
}
