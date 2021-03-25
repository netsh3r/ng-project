using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ng_project.Managers
{
	//</ineritdoc>
	public abstract class BaseEntityManager<T, IdT> : IBaseEntityManager<T, IdT>
	{
		public abstract ICollection<T> FindAll(Expression<Func<T, object>> expression);
		public abstract ICollection<T> FindAll(Expression<Func<T, object>> expression, Func<object, bool> func);
		//</inheritdoc>
		public abstract ICollection<T> FindAll(Func<T, bool> expression);
		//</ineritdoc>
		public abstract void Add(T entity);
		//</ineritdoc>
		public abstract void Delete(int id);
		//</ineritdoc>
		public abstract void Save(T entity);
		//</ineritdoc>
		public abstract ICollection<T> FindAll();
		//</ineritdoc>
		public abstract T FindById(int id);
		public abstract T Find(Expression<Func<T, object>> expression, int id);
		//</inheritdoc>
		public abstract T Find(Func<T, bool> expression);
		public abstract T Find(Expression<Func<T, object>> expression, Expression<Func<object, bool>> func);
	}
}
