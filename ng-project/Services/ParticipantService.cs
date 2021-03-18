using ng_project.Entities;
using ng_project.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ng_project.Services
{
	public class ParticipantService : IParticipantService
	{
		public ParticipantService()
		{
			participantManager = ParticipantManager.Instance;
		}
		private ParticipantManager participantManager;
		public List<Participant> GetAll()
		{
			return participantManager.FindAll().ToList();
		}
	}
}
