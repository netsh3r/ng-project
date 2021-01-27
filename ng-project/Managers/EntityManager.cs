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
	public class EntityManager<T, IdT> : BaseEntityManager<T, IdT> where T:Entity<IdT>
	{
		
		public override void Add(T entity)
		{
			using(var db = new NgContext())
			{
				var _dbSet = db.Set<T>();
				_dbSet.Add(entity);
				//_dbSet.AddRange(new List<T>() { entity });
				//db.Users.Add(entity as User);
				db.SaveChanges();
			}
		}

		public override void Delete(IdT id)
		{
			throw new NotImplementedException();
		}

		public override void Edit(T entity)
		{
			throw new NotImplementedException();
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
