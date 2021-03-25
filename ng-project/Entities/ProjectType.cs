using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// тип проекта
	/// </summary>
	public class ProjectType : Entity
	{
		/// <summary>
		/// Название проекта
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Набор базовых навыков
		/// </summary>
		public List<Skill> BaseSkills { get; set; }
		/// <summary>
		/// Проекты этого типа
		/// </summary>
		public List<Project> Projects { get; set; }
	}
}
