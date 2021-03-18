using ng_project.Entities;
using ng_project.Managers;
using ng_project.SDK;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
		public T FindByFunc<T, IdT>(Func<T, bool> func) where T : Entity<IdT>, new()
		{
			return EntityManager<T, IdT>.Instance.Find(func);
		}
		public T GetById<T,IdT>(IdT id) where T : Entity<IdT>, new()
		{
			return EntityManager<T, IdT>.Instance.FindById(id);
		}
		public ICollection<T> GetAll<T,IdT>() where T:Entity<IdT>, new()
		{
			return EntityManager<T,IdT>.Instance.FindAll();
		}
		public ICollection<T> GetAll<T,IdT>(Func<T,bool> expression) where T:Entity<IdT>, new()
		{
			return EntityManager<T,IdT>.Instance.FindAll(expression);
		}
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

		public void Add<T, IdT>(T model) where T : Entity<IdT>, new()
		{
			EntityManager<T, IdT>.Instance.Add(model);
		}

		public void Save<T, IdT>(T model) where T : Entity<IdT>, new()
		{
			EntityManager<T, IdT>.Instance.Edit(model);
		}
	}
}
