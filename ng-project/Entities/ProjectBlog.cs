using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Блог проекта
	/// </summary>
	public class ProjectBlog : Entity
	{
		/// <summary>
		/// Заголовок
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// Текст из блога
		/// </summary>
		public string Text { get; set; }
		/// <summary>
		/// Заглавное изображение
		/// </summary>
		public byte[] Image { get; set; }
	}
}
