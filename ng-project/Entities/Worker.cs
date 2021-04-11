using ng_project.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Сотрудник
	/// </summary>
	public class Worker : Entity
	{
		/// <summary>
		/// Ссылка на пользователя
		/// </summary>
		public virtual User User { get; set; }
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public int UserId { get; set; }
		/// <summary>
		/// Список проектов сотрудника
		/// </summary>
		public virtual List<Project> Projects { get; set; } 
		/// <summary>
		/// Связь навык-пользователь
		/// </summary>
		public virtual List<SkillWorker> SkillWorkers { get; set; }
		/// <summary>
		/// Навыки
		/// </summary>
		[NotMapped]
		public List<Skill> Skills
		{
			get
			{
				return SkillWorkers?.Select(t => new Skill()
				{
					Id = t.SkillId
				}).ToList();
			}
			set
			{
				Skills = value;
				SkillWorkers = Skills?.Select(t => new SkillWorker()
				{
					SkillId = Id,
					WorkerId = t.Id
				}).ToList();
			}
		}
	}
}
