using Microsoft.EntityFrameworkCore;
using ng_project.Context;
using ng_project.Entities;
using ng_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Managers
{
	public class WorkerManager : EntityManager<Worker, int>,IIncludeService<Worker,int>
	{
		private static WorkerManager _instance;
		public static WorkerManager Instance
		{
			get
			{
				return _instance ?? (_instance = new WorkerManager());
			}
		}

		public Worker Find(List<ExpressionEntity> expEntity)
		{
			throw new NotImplementedException();
		}

		public Worker Find(Func<Worker, bool> func, List<ExpressionEntity> expEntity)
		{
			throw new NotImplementedException();
		}

		public override ICollection<Worker> FindAll()
		{
			using(var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var model = db.Participants.Select(t=> new Worker { User = t.User }).ToList();
				return model;
			}
		}
		public override ICollection<Worker> FindAll(Func<Worker, bool> func)
		{
			using (var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var model = db.Participants
					.AsNoTracking()
					.Include(t => t.Skills)
					.AsNoTracking()
					.Include(t => t.User)
					.AsNoTracking()
					.Where(func)
					.ToList();
				return model;
			}
		}

		public List<Worker> FindAll(Expression<Func<Worker, object>> expEntity)
		{
			using(var db = new NgContext())
			{
				dynamic model = db.Participants.Select(expEntity).ToList();
				return model;
			}
		}
		public Expression<Func<Worker, object>> Test(Expression<Func<Worker,object>> expression)
		{
			return null;
		}
		public ICollection<Worker> FindAll(Func<Worker, bool> func, List<ExpressionEntity> expEntity)
		{
			throw new NotImplementedException();
		}
	}
}
