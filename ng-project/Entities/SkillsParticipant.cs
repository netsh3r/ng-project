using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	public class SkillsParticipant : Entity<int>
	{
		public Skill Skill { get; set; }
		public int SkillId { get; set; }

		public Participant Participant { get; set; }
		public int ParticipantId { get; set; }

	}
}
