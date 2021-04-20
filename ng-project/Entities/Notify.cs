using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Сущность уведомление
	/// </summary>
	public class Notify:Entity
	{
		public Project Project { get; set; }
		public int ProjectId { get; set; }
		/// <summary>
		/// Прочитано ли уведомление
		/// </summary>
		public bool IsReading { get; set; } = false;
		/// <summary>
		/// Отправитель
		/// </summary>
		public User Sender { get; set; }
		/// <summary>
		/// Id отправителя
		/// </summary>
		public int SenderId { get; set; }
		/// Получатель
		/// </summary>
		public User Recipient { get; set; }
		/// <summary>
		/// Id получателя
		/// </summary>
		public int RecipientId { get; set; }
		/// <summary>
		/// Дата отправки
		/// </summary>
		public DateTime SendDate { get; set; }
		/// <summary>
		/// Сообщение
		/// </summary>
		public string Message { get; set; }
	}
}
