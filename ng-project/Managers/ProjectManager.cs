using Microsoft.EntityFrameworkCore;
using ng_project.Context;
using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public override Project FindById(int id)
		{
			using(var db = new NgContext())
			{
				var model = db.Projects
					.Include(t => t.News)
					.Include(t => t.User)
					.Include(t => t.ProjectImage)
					.Include(t => t.MainProjectImage)
					.FirstOrDefault(t => t.Id == id);
				return model;
			}
		}

		public override ICollection<Project> FindAll()
		{
			using(var db = new NgContext())
			{
				var model = db.Projects
					.Include(t => t.User)
					.Include(t => t.MainProjectImage)
					.Include(t=> t.ProjectImage)
					.ToList();
				return model;
			}
		}
	}
}
