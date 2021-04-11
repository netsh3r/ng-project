using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Сущность связи участника и его навыка
	/// </summary>
	public class SkillWorker : Entity
	{
		public Worker Worker { get; set; }
		public int WorkerId { get; set; }
		public Skill Skill { get; set; }
		public int SkillId { get; set; }
	}
}
