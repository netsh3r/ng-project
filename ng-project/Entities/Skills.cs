using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	public class Skills:Entity<int>
	{
		public string Name { get; set; }
		public Participant Participant { get; set; }
		public int ParticipantId { get; set; }
	}
}
