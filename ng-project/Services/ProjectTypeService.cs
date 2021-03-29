using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Services
{
	public class ProjectTypeService : MainService<ProjectType, int>, IProjectTypeService
	{
		private static ProjectTypeService _instance;
		public static ProjectTypeService Instance
		{
			get
			{
				return _instance ?? (_instance = new ProjectTypeService());
			}
		}
	}
}
