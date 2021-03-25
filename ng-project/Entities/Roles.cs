using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ng_project.Entities
{
	public class Roles : Entity<int>
	{
		public string Name { get; set; }
	}
}
