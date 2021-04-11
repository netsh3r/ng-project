using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Навыки
	/// </summary>
	public class Skill:Entity
	{
		/// <summary>
		/// Наименование навыка
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Список сотрудников использующих навык
		/// </summary>
		//public virtual List<Worker> Workers { get; set; }
		/// <summary>
		/// Связь навык-пользователь
		/// </summary>
		public virtual List<SkillWorker> SkillWorkers { get; set; }
		/// <summary>
		/// Навыки
		/// </summary>
		[NotMapped]
		public List<Worker> Workers
		{
			get
			{
				return SkillWorkers?.Select(t => new Worker()
				{
					Id = t.WorkerId
				}).ToList();
			}
			set
			{
				Workers = value;
				SkillWorkers = Workers?.Select(t => new SkillWorker()
				{
					WorkerId = Id,
					SkillId = t.Id
				}).ToList();
			}
		}
		/// <summary>
		/// Список проектов использующих навык
		/// </summary>
		public virtual List<Project> Projects { get; set; }
		/// <summary>
		/// Список типов проектов, используемых навык в качестве базового
		/// </summary>
		public virtual List<ProjectType> ProjectTypes { get; set; }
	}
}
