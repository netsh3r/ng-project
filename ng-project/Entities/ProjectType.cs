using ng_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// тип проекта
	/// </summary>
	public class ProjectType : Entity
	{
		public List<ProjectTypeRoles> ProjectTypesRoles { get; set; }
		[NotMapped]
		public List<Roles> Roles
		{
			get
			{
				return ProjectTypesRoles?.Select(t => new Roles()
				{
					Id = t.RolesId
				}).ToList();
			}
			set
			{
				Roles = value;
				ProjectTypesRoles = Roles.Select(t =>
				new ProjectTypeRoles()
				{
					ProjectTypeId = Id,
					RolesId = t.Id
				}).ToList();
			}
		}
		/// <summary>
		/// Название иконки
		/// </summary>
		public string IconName { get; set; }
		/// <summary>
		/// Название проекта
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Набор базовых навыков
		/// </summary>
		public virtual List<Skill> BaseSkills { get; set; }
		/// <summary>
		/// Проекты этого типа
		/// </summary>
		public virtual List<Project> Projects { get; set; }
		/// <summary>
		/// Подтип
		/// </summary>
		public virtual List<ProjectSubType> ProjectSubType { get; set; } = new List<ProjectSubType>();
	}
}
