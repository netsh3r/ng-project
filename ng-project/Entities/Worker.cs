using ng_project.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		/// Навыки
		/// </summary>
		public virtual List<Skill> Skills { get; set; }
	}
}
