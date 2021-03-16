using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	public class Project : Entity<int>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string ShortDescription { get; set; }

		public virtual List<News> News { get; set; } = new List<News>();
	}
}
