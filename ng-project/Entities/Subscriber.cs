using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Подписчик
	/// </summary>
	public class Subscriber : Entity
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
		/// Список проектов пользователя
		/// </summary>
		public List<Project> Projects { get; set; } = new List<Project>();
	}
}

