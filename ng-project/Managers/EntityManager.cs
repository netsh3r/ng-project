using ng_project.Context;
using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ng_project.Managers
{
	/// <summary>
	/// Менеджер для работы с данными
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="IdT"></typeparam>
	public class EntityManager<T, IdT> : BaseEntityManager<T, IdT> where T:Entity<IdT>, new()
	{
		public override void Add(T entity)
		{
			using(var db = new NgContext())
			{
				var _dbSet = db.Set<T>();
				_dbSet.Add(entity);
				db.SaveChanges();
			}
		}

		public override void Delete(IdT id)
		{
			using (var db = new NgContext())
			{
				var dbSet = db.Set<T>();
				dbSet.Remove(new T(){Id = id});
				db.SaveChanges();
			}
		}

		public override void Edit(T entity)
		{
			using (var db = new NgContext())
			{
				var dbSet = db.Set<T>();
				dbSet.Update(entity);
			}
		}

		public override ICollection<T> FindAll()
		{
			using(var db = new NgContext())
			{
				var _dbSet = db.Set<T>();
				return _dbSet.ToList();
			}
		}

		public override T FindById(IdT id)
		{
			using (var db = new NgContext())
			{
				var _dbSet = db.Set<T>();
				return _dbSet.Find(id);
			}
		}
	}
}
