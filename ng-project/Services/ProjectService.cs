using ng_project.Entities;
using ng_project.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Services
{
	public class ProjectService : IProjectService
	{
		public ProjectService()
		{
			projectManager = ProjectManager.Instance;
		}
		private ProjectManager projectManager;
		public Project FindById(int id)
		{
			return projectManager.FindById(id);
		}

		public ICollection<Project> GetAll()
		{
			return projectManager.FindAll();
		}

		public ICollection<Project> GetAll(Func<Project, bool> expression)
		{
			return projectManager.FindAll(expression);
		}
	}
}
