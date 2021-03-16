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
		public List<Skills> Skills { get; set; } = new List<Skills>();
		/// <summary>
		/// Роль в команде
		/// </summary>
		public Roles Roles { get; set; }
		/// <summary>
		/// Ссылка на пользователя
		/// </summary>
		public User User { get; set; }
		public int UserId { get; set; }
	}
}
