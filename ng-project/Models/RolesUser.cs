using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ng_project.Models
{
	public class RolesUser :Entity
	{
		[NotMapped]
		public override int Id { get; set; }
		public Roles Roles { get; set; }
		public int RolesId { get; set; }
		public User Users { get; set; }
		public int UsersId { get; set; }
	}
}
