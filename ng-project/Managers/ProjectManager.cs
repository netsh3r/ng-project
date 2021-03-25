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
		public void AddSubscriber(int projectId, int subscriberId)
		{
			using(var db = new NgContext())
			{
				var model = db.Projects
					.Include(t=> t.Subscribers)
					.FirstOrDefault(t=> t.Id == projectId);
				var subscriber = db.Subscribers.Find(subscriberId);
				model.Subscribers.Add(subscriber);
				db.SaveChanges();
			}
		}
		public void AddParticipant(int projectId, int workerId)
		{
			using (var db = new NgContext())
			{
				var model = db.Projects
					.Include(t => t.Workers)
					.FirstOrDefault(t => t.Id == projectId);
				var worker = db.Participants.Find(workerId);
				model.Workers.Add(worker);
				db.SaveChanges();
			}
		}
		public override Project FindById(int id)
		{
			using(var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var model = db.Projects
					//.AsNoTracking()
					//.Include(t => t.News)
					//.AsNoTracking()
					.Include(t => t.Workers)
					//.AsNoTracking()
					.Include(t => t.User)
					//.AsNoTracking()
						.ThenInclude(t => t.Image)
					//.AsNoTracking()
					.Include(t => t.ProjectImage)
					//.AsNoTracking()
					.Include(t => t.Subscribers)
					//.AsNoTracking()
					//.Include(t => t.MainProjectImage)
					//.AsNoTracking()
					.FirstOrDefault(t => t.Id == id);
				return model;
			}
		}

		public override ICollection<Project> FindAll()
		{
			using(var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var model = db.Projects
					.AsNoTracking()
					.Include(t => t.User)
						.ThenInclude(t => t.Image)
					//.AsNoTracking()
					.Include(t => t.Workers)
					//.AsNoTracking()
					
					//.AsNoTracking()
					.Include(t => t.MainProjectImage)
					//.AsNoTracking()
					.Include(t=> t.ProjectImage)
					//.AsNoTracking()
					.ToList();
				return model;
			}
		}

		public override ICollection<Project> FindAll(Func<Project, bool> expression)
		{
			using (var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var model = db.Projects
					.AsNoTracking()
					.Include(t => t.User)
					.AsNoTracking()
					.Include(t => t.MainProjectImage)
					.AsNoTracking()
					.Include(t => t.ProjectImage)
					.AsNoTracking()
					.Include(t => t.Workers)
					.AsNoTracking()
					.Where(expression)
					.ToList();
				return model;
			}
		}
	}
}
