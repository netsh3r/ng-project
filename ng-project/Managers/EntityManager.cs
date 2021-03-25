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
	/// <summary>
	/// Менеджер для работы с данными
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="IdT"></typeparam>
	public class EntityManager<T, IdT> : BaseEntityManager<T, IdT> where T:Entity, new()
	{
		private static EntityManager<T, IdT> _instance;
		public static EntityManager<T, IdT> Instance
		{
			get
			{
				return _instance ?? (_instance = new EntityManager<T, IdT>());
			}
		}
		public override void Add(T entity)
		{
			using(var db = new NgContext())
			{
				var _dbSet = db.Set<T>();
				_dbSet.Add(entity);
				db.SaveChanges();
			}
		}

		public override void Delete(int id)
		{
			using (var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var dbSet = db.Set<T>();
				dbSet.Remove(new T(){Id = id});
				db.SaveChanges();
			}
		}

		public override void Save(T entity)
		{
			using (var db = new NgContext())
			{
				var dbSet = db.Set<T>();
				dbSet.Update(entity);
				db.SaveChanges();
			}
		}

		public override ICollection<T> FindAll()
		{
			using(var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var _dbSet = db.Set<T>();
				return _dbSet.ToList();
			}
		}
		public override ICollection<T> FindAll(Expression<Func<T,object>> expression)
		{
			using (var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var _dbSet = db.Set<T>().Select(expression).ToList();
				return _dbSet.Cast<T>().ToList();
			}
		}
		public override T Find(Func<T, bool> expression)
		{
			using(var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var _dbSet = db.Set<T>();
				return _dbSet.ToList().FirstOrDefault(expression);
			}
		}
		public override ICollection<T> FindAll(Func<T, bool> expression)
		{
			using (var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var _dbSet = db.Set<T>();
				return _dbSet.ToList().Where(expression).ToList();
			}
		}
		public override T FindById(int id)
		{
			using (var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var _dbSet = db.Set<T>();
				return _dbSet.Find(id);
			}
		}

		public override T Find(Expression<Func<T, object>> expression, int id)
		{
			using(var db = new NgContext())
			{
				var _dbSet = db.Set<T>().Select(expression).FirstOrDefault(t=> (t as T).Id == id);
				return (T)_dbSet;
			}
		}

		public override T Find(Expression<Func<T, object>> expression, Expression<Func<object, bool>> func)
		{
			using (var db = new NgContext())
			{
				var _dbSet = db.Set<T>().Select(expression).FirstOrDefault(func);
				return (T)_dbSet;
			}
		}

		public override ICollection<T> FindAll(Expression<Func<T, object>> expression, Func<object, bool> func)
		{
			using (var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var _dbSet = db.Set<T>().Select(expression).ToList().Where(func);
				return _dbSet.Cast<T>().ToList();
			}
		}
	}
}
