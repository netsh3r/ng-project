using System;
using System.Collections.Generic;
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
		public List<Worker> Workers { get; set; }
		/// <summary>
		/// Список проектов использующих навык
		/// </summary>
		public List<Project> Projects { get; set; }
		/// <summary>
		/// Список типов проектов, используемых навык в качестве базового
		/// </summary>
		public List<ProjectType> ProjectTypes { get; set; }
	}
}
