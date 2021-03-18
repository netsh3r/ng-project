using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Managers
{
    public class ProjectManager : EntityManager<Project, int>
	{ 
		private static ProjectManager _instance;
		public static ProjectManager Instance
		{
			get
			{
				return _instance ?? (_instance = new ProjectManager());
			}
		}
	}
}
