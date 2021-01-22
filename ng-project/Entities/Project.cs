using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	public class Project : Entity<long>
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
