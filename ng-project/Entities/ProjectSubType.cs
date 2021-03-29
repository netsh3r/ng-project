using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	public class ProjectSubType : Entity
	{
		public Project Project { get; set; }
		public ProjectType ProjectType { get; set; }
		public int ProjectTypeId { get; set; }
		public string Name { get; set; }
	}
}
