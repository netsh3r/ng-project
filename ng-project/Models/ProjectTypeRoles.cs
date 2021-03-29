using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ng_project.Models
{
	public class ProjectTypeRoles:Entity
	{
		public static List<Roles> Select { get; internal set; }
		[NotMapped]
		public override int Id { get; set; }
		public Roles Roles { get; set; }
		public int RolesId { get; set; }
		public ProjectType ProjectType { get; set; }
		public int ProjectTypeId { get; set; }
	}
}
