using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Обозначение новости
	/// </summary>
	public class Teg :Entity
	{
		/// <summary>
		/// Название
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Список новостей, используемых выбранный тег
		/// </summary>
		public List<News> News { get; set; }
	}
}
