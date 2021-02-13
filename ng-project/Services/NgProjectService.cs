using ng_project.Entities;
using ng_project.Managers;
using ng_project.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Services
{

	//</inheritdoc>
	[Service]
	public class NgProjectService : INgProjectService
	{
		private static NgProjectService _instance;
		public static NgProjectService Instance
		{
			get
			{
				return _instance ?? (_instance = new NgProjectService());
			}
		}

		#region Managers
		private UserManager UserManager;
		private ProjectManager ProjectManager;
		#endregion

		

		public NgProjectService()
		{
			this.UserManager = UserManager.Instance;
			this.ProjectManager = ProjectManager.Instance;
		}
		
		//</inheritdoc>
		public ICollection<User> GetAllUsers()
		{
			return UserManager.FindAll();
		}

        public User FindUserById(int Id)
        {
			return UserManager.FindById(Id);
        }

		public ICollection<Project> GetAllProject()
		{
			return ProjectManager.FindAll();
		}

		public Project FindProjectById(int Id)
		{
			return ProjectManager.FindById(Id);
		}

		public void AddProject(Project project)
		{
			ProjectManager.Add(project);
		}
	}
}
