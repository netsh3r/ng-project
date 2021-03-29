using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Services
{
	public class ProjectSubTypeService : MainService<ProjectSubType,int>,IProjectSubTypeService
	{
		private static ProjectSubTypeService _instance;
		public static ProjectSubTypeService Instance
		{
			get
			{
				return _instance ?? (_instance = new ProjectSubTypeService());
			}
		}
	}
}
