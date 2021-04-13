using Microsoft.EntityFrameworkCore;
using ng_project.Context;
using ng_project.Entities;
using ng_project.EntityExpressions;
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
	public class EntityManager<T, IdT> : BaseEntityManager<T, IdT> where T : Entity, new()
	{
		private static EntityManager<T, IdT> _instance;
		public static EntityManager<T, IdT> Instance
		{
			get
			{
				return _instance ?? (_instance = new EntityManager<T, IdT>());
			}
		}

		public override int Add(T entity)
		{
			using(var db = new NgContext())
			{
				var _dbSet = db.Set<T>();
				var item = _dbSet.Add(entity);
				db.SaveChanges();
				return item.Entity.Id;
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
				db.Update(entity);
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
				var _dbSet = db.Set<T>().Select(expression).AsNoTracking().ToList();
				return _dbSet.Cast<T>().ToList();
			}
		}
		public override T Find(Func<T, bool> expression)
		{
			using(var db = new NgContext())
			{
				var _dbSet = db.Set<T>();
				return _dbSet.FirstOrDefault(expression);
			}
		}
		public override ICollection<T> FindAll(EntityExpression<T> entityExpression, Func<T, bool> func = null)
		{
			using (var db = new NgContext())
			{
				var _dbSet = db.Set<T>().Include(entityExpression.ExpressionList.First());
				foreach (var exp in entityExpression.ExpressionList)
				{
					_dbSet = _dbSet.Include(exp);
				}
				if(func != null)
					return _dbSet.Where(func).ToList();
				return _dbSet.ToList();
			}
		}
		public override T Find(EntityExpression<T> entityExpression, Func<T, bool> func = null)
		{
			using (var db = new NgContext())
			{
				var _dbSet = db.Set<T>().Include(entityExpression.ExpressionList.First());
				foreach (var exp in entityExpression.ExpressionList)
				{
					_dbSet = _dbSet.Include(exp);
				}
				return _dbSet.Where(func).FirstOrDefault();
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
				var _dbSet = db.Set<T>().Select(expression).ToList().FirstOrDefault(t=> (t as T).Id == id);
				return (T)_dbSet;
			}
		}
		delegate Expression<Func<T, object>> M();
		public override T Find(Expression<Func<T, object>> expression, Func<object, bool> func)
		{
			using (var db = new NgContext())
			{
				var _dbSet = db.Set<T>().Select(expression).AsEnumerable().FirstOrDefault(func);
				return (T)_dbSet;
			}
		}

		public override ICollection<T> FindAll(Expression<Func<T, object>> expression, Func<object, bool> func)
		{
			using (var db = new NgContext())
			{
				db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				var _dbSet = db.Set<T>().Select(expression).AsNoTracking().ToList().Where(func);
				return _dbSet.Cast<T>().ToList();
			}
		}

		public override void RemoveLink(object link)
		{
			using(var db = new NgContext())
			{
				db.Remove(link);
				db.SaveChanges();
			}
		}
	}
}
