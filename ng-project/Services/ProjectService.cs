using ng_project.Entities;
using ng_project.Managers;
using ng_project.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Services
{
	[Service]
	public class ProjectService : MainService<Project,int>, IProjectService
	{
		public ProjectService()
		{
			projectManager = ProjectManager.Instance;
		}
		private ProjectManager projectManager;

		public ICollection<Project> GetAll()
		{
			return projectManager.FindAll();
		}

		public ICollection<Project> GetAll(Func<Project, bool> expression)
		{
			return projectManager.FindAll(expression);
		}

		public void AddSubscribe(int projectId, int subscriberId)
		{
			projectManager.AddSubscriber(projectId, subscriberId);
		}
		public void AddParticipant(int projectId, int workerId)
		{
			projectManager.AddParticipant(projectId, workerId);
		}
	}
}
