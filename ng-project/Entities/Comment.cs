using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Комментарии
	/// </summary>
	public class Comment :Entity
	{
		/// <summary>
		/// Проект
		/// </summary>
		public Project Project { get; set; }
		/// <summary>
		/// Идентификатор проекта
		/// </summary>
		public int ProjectId { get; set; }
		/// <summary>
		/// Ссылка на пользователя
		/// </summary>
		public User User { get; set; }
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public int UserId { get; set; }
		/// <summary>
		/// Текст комментария
		/// </summary>
		public string Text { get; set; }
		/// <summary>
		/// Дата публикации
		/// </summary>
		public DateTime PublishDate { get; set; }

	}
}
