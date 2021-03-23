using ng_project.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	public class Participant : Entity<int>
	{
		/// <summary>
		/// Навыки
		/// </summary>
		public List<SkillsParticipant> Skills { get; set; } = new List<SkillsParticipant>();

		/// <summary>
		/// Роль в команде
		/// </summary>
		public Roles Roles { get; set; }
		/// <summary>
		/// Ссылка на пользователя
		/// </summary>
		public User User { get; set; }
		public int UserId { get; set; }
		public List<ProjectParticipant> ProjectParticipant { get; set; } = new List<ProjectParticipant>();
	}
}
