using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Создатель
	/// </summary>
	public class Creator : Entity
	{
		/// <summary>
		/// Ссылка на пользователя
		/// </summary>
		public virtual User User { get; set; }
		/// <summary>
		/// идентификатор пользователя
		/// </summary>
		public int UserId { get; set; }
	}
}
