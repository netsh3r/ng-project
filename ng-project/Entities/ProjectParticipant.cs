using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	public class ProjectParticipant: Entity<int>
	{
		public Participant Participant { get; set; }
		public Project Project { get; set; }
		public int ParticipantId { get; set; }
		public int ProjectId { get; set; }

	}
}
