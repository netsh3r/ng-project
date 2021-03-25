using ng_project.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Сотрудник
	/// </summary>
	public class Worker : Entity<int>
	{
		/// <summary>
		/// Ссылка на пользователя
		/// </summary>
		public User User { get; set; }
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public int UserId { get; set; }
		/// <summary>
		/// Список проектов сотрудника
		/// </summary>
		public List<Project> Projects { get; set; }
		/// <summary>
		/// Навыки
		/// </summary>
		public List<Skill> Skills { get; set; }
	}
}
