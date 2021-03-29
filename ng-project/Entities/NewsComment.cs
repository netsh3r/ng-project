using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	public class NewsComment :Entity
	{
		/// <summary>
		/// Комментарии
		/// </summary>
		public List<Comment> Comments { get; set; }
		/// <summary>
		/// Пользователь
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
		/// Новость
		/// </summary>
		public News News { get; set; }
		/// <summary>
		/// Идентификатор новости
		/// </summary>
		public int NewsId { get; set; }
	}
}
